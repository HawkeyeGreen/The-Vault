using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

namespace The_Vault.Technic
{
    /* Klasse: TextureManager
     * Erzeugungsmuster: 
     * wird durch Singleton
     * stellt bereit: Factory
     * 
     * Der TextureManager lädt alle Texturen und stellt sie via einer getTexture-Methode bereit.
     * Auf Texturen verweist eine eindeutige Klartextbezeichnung ("baseGrass_01").
     * 
     * Feature: TextureAtlas
     * Ein TextureAtlas enthält eine Liste von Texturen, die genutzt werden können, um einen bestimmten Style zu erreichen.
     */
    class TextureManager
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();
        Random random = new Random();

        private Dictionary<string, Texture2D> textureDictionary;
        private Dictionary<string, string> pathDictionary;

        private Dictionary<string, List<string>> textureAtlasses;


        static private TextureManager instance;
        static private ContentManager contentManager;

        private TextureManager()
        {
            textureDictionary = new Dictionary<string, Texture2D>();
            pathDictionary = new Dictionary<string, string>();
            textureAtlasses = new Dictionary<string, List<string>>();
        }

        public void initialize(ContentManager content)
        {
            contentManager = content;
            loadTexturePaths();
        }

        public static TextureManager getInstance()
        {
            if(instance == null)
            {
                instance = new TextureManager();
            }
            return instance;
        }

        // Diese Funktion gibt eine zu Key passende Textur zurück.
        // Sie akzeptiert entweder einen Texture-Key oder einen TextureAtlas-Key.
        // Bei einem Atlas-Key wird eine zufällige Textur aus dem Atlas zurückgegeben.
        public Texture2D GetTexture(string key)
        {
            if(textureDictionary.ContainsKey(key) == false)
            {
                if(pathDictionary.ContainsKey(key))
                {
                    textureDictionary.Add(key, contentManager.Load<Texture2D>(pathDictionary[key]));
                }
                else if(textureAtlasses.ContainsKey(key))
                {
                    List<string> texIDs = textureAtlasses[key];
                    return GetTexture(texIDs[random.Next(0, texIDs.Count)]);
                }
                else
                {
                    return GetTexture("NotFound");
                }
            }
            return textureDictionary[key];
        }

        // Diese Methode gibt eine TextureID aus einem TextureAtlas zurück.
        public string getTextureIDFromAtlas(string key)
        {
            if (textureAtlasses.ContainsKey(key))
            {
                List<string> texIDs = textureAtlasses[key];
                return texIDs[random.Next(0, texIDs.Count)];
            }
            else
            {
                return "NotFound";
            }
        }

        /* Diese Methode lädt alle Texture-Pfade mit ihren Keys in das
         * pathDictionary. Hier für geht die Methode alle Ordner unterhalb von Content/textures durch und speichert für
         * alle .pngs unter ihren Namen den Pfad ab.
         */
        private void loadTexturePaths()
        {
            //AllocConsole();
            Console.WriteLine("Start: Laden der Texturen");
            directoryDiveTexPaths(AppDomain.CurrentDomain.BaseDirectory + "/Content/textures");
        }


        private void directoryDiveTexPaths(string root)
        {
            // Texturen in diesem Ordner
            string[] textures = Directory.GetFiles(root, "*.xnb");
            foreach (string tex_path in textures)
            {
                FileInfo tex = new FileInfo(tex_path);
                Console.WriteLine("Gefunden: " + tex.Name.Replace(".xnb", "") + " In Pfad: " + tex_path.Replace(".xnb", ""));
                pathDictionary.Add(tex.Name.Replace(".xnb", ""), tex_path.Replace(".xnb", ""));
            }
            // Atlasses in diesem Ordner
            string[] atlasses = Directory.GetFiles(root, "*.txt");
            foreach (string atlas_path in atlasses)
            {
                FileInfo atlas = new FileInfo(atlas_path);
                string atlasName = atlas.Name.Replace(".txt", "");
                textureAtlasses.Add(atlasName, new List<string>());
                Console.WriteLine("Gefunden: " + atlasName + " In Pfad: " + atlas_path.Replace(".txt", ""));
                StreamReader reader = new StreamReader(File.OpenRead(atlas.FullName));
                while(reader.EndOfStream == false)
                {
                    textureAtlasses[atlasName].Add(Convert.ToString(reader.ReadLine()));
                }
                reader.Close();
            }
            // Unter Ordner
            string[] folders = Directory.GetDirectories(root);
            Console.WriteLine("Gefundende Ordner: " + folders.Length.ToString());
            foreach (string folder in folders)
            {
                Console.WriteLine("Gehe zu Ordner: " + folder);
                directoryDiveTexPaths(folder);
            }
        }
    }
}
