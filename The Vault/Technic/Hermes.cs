using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace The_Vault.Technic
{
    /* Hermes - General Purpose Messaging System
     * Hermes sammelt Zustandsmeldung etc. von beliebigen GameObjects und sammelt
     * diese sowohl in einem geschriebenen Log als auch in einer zur Laufzeit verfügbaren Sammlung.
     * 
     * Darüber hinaus stehen das HermesBlackboard für die Kommunikation zwischen verschiedenen Programmteilen
     * und das PlayerMessage-Log zu Verfügung. Letzteres dient dafür Meldungen aufzunehmen, die für den SC relevant sind.
     * 
     */
    class Hermes
    {
        private static Hermes instance = null;

        private static Object instanceLock = new Object();
        private Object blackboardLock;
        private Object mainLogLock;
        private Object queueMainLogLock;


        private Dictionary<GameObject, List<Tuple<string, GameObject>>> blackboard;

        private Dictionary<GameObject, string> mainLog;
        private HermesMainLogger mainLogger;
        private Queue<Tuple<GameObject, string>> queueMainLog;
        private Thread mainLogThread;


        private Hermes()
        {
            blackboard = new Dictionary<GameObject, List<Tuple<string, GameObject>>>();
            blackboardLock = new Object();

            mainLog = new Dictionary<GameObject, string>();
            mainLogLock = new Object();

            queueMainLog = new Queue<Tuple<GameObject, string>>();
            queueMainLogLock = new Object();

            mainLogger = new HermesMainLogger(AppDomain.CurrentDomain.BaseDirectory + "MainLog.txt", queueMainLog, queueMainLogLock);
            mainLogThread = new Thread(new ThreadStart(mainLogger.log));
            mainLogThread.Start();
        }

        public static Hermes getInstance()
        {
            if(instance == null)
            {
                lock(instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new Hermes();
                    }
                }
            }
            return instance;
        }


        #region BlackBoard
        public void lodgeBlackboardMessage(GameObject sender, GameObject receiver, string message)
        {
            lock(blackboardLock)
            {
                if (!blackboard.ContainsKey(receiver))
                {
                    blackboard.Add(receiver,new List<Tuple<string, GameObject>>());
                }
                blackboard[receiver].Add(new Tuple<string, GameObject>(message, sender));
            }

            Console.WriteLine("BlackboardMessage lodged from " + sender.ID.ToString() + " of type " + sender.MyType + " for " + receiver.ID.ToString() + "! Message" + message);
        }

        public List<Tuple<string, GameObject>> getBlackBoardMessages(GameObject receiver)
        {
            lock (blackboardLock)
            {
                List<Tuple<string, GameObject>> messages = blackboard[receiver];
                blackboard.Remove(receiver);
                return messages;
            }
        }

        public bool lookForBlackBoardMessages(GameObject receiver)
        {
            lock (blackboardLock)
            {
                return blackboard.ContainsKey(receiver);
            }
        }
        #endregion

        #region MainLog
        public void log(GameObject sender, string entry)
        {
            lock(queueMainLogLock)
            {
                queueMainLog.Enqueue(new Tuple<GameObject, string>(sender, entry));
            }
        }
        #endregion

        public void shutdownHermes()
        {
            log(new SystemObject(), "ShutdownSignal");
            while(!mainLogger.ended)
            {

            }
            mainLogThread.Abort();
        }
    }

    class HermesMainLogger
    {
        private StreamWriter writer;
        private Object queueLock;
        private Queue<Tuple<GameObject, string>> queue;

        private bool run = true;
        public bool Running { get => run; set => run = value; }

        public bool ended = false;

        public HermesMainLogger(string filePath, Queue<Tuple<GameObject, string>> _Queue, Object Lock)
        {
            if(File.Exists(filePath))
            {
                string newPath = filePath.Replace("MainLog", "MainLog_Archived" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                File.Move(filePath, newPath);
            }


            writer = new StreamWriter(File.OpenWrite(filePath));

            queue = _Queue;
            queueLock = Lock;
        }

        public void log()
        {
            #region do Logging
            while(run)
            {
                while (queue.Count == 0)
                {
                    System.Threading.Thread.Sleep(100);
                }

                lock(queueLock)
                {
                    Tuple<GameObject, string> entry = queue.Dequeue();
                    if(entry.Item2 == "ShutdownSignal")
                    {
                        Running = false;
                    }
                    string logEntry = entry.Item1.ID.ToString() + " | " + entry.Item1.MyType + ": " + entry.Item2;
                    Console.WriteLine(logEntry);
                    writer.WriteLine(logEntry);
                }
            }
            #endregion

            #region stopLogger
            writer.Close();

            ended = true;
            #endregion
        }
    }

    
}
