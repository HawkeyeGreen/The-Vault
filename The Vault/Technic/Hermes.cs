using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static readonly Lazy<Hermes> lazy =
        new Lazy<Hermes>(() => new Hermes());

        private Dictionary<GameObject, List<Message>> blackboard = new Dictionary<GameObject, List<Message>>();

        private Hermes()
        {

        }

        public static Hermes Instance { get { return lazy.Value; } }

        public void lodgeBlacboardMessage(GameObject sender, GameObject receiver, string message)
        {
            if(!blackboard.ContainsKey(receiver))
            {
                blackboard.Add(receiver, new List<Message>());
            }
            blackboard[receiver].Add(new Message(sender, message));
        }

        class Message
        {
            private GameObject sender;
            public GameObject Sender { get => sender; set => sender = value; }

            private string text;
            public string Text { get => text; set => text = value; }

            public Message(GameObject sender, string text)
            {
                this.Sender = sender;
                this.Text = text;
            }
        }
    }
}
