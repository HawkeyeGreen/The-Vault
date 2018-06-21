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
     */
    class TextureManager
    {
        [DllImport("kernel32")]
        static extern bool AllocConsole();

        private Dictionary<string, Texture2D> textureDictionary;
        private Dictionary<string, string> pathDictionary;
        static private TextureManager instance;
        static private ContentManager contentManager;

        private TextureManager()
        {
            textureDictionary = new Dictionary<string, Texture2D>();
            pathDictionary = new Dictionary<string, string>();
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

        public Texture2D GetTexture(string key)
        {
            if(textureDictionary.ContainsKey(key) == false)
            {
                if(pathDictionary.ContainsKey(key))
                {
                    textureDictionary.Add(key, contentManager.Load<Texture2D>(pathDictionary[key]));
                }
                else
                {
                    return GetTexture("NotFound");
                }
            }
            return textureDictionary[key];
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
            string[] textures = Directory.GetFiles(root, "*.xnb");
            foreach (string tex_path in textures)
            {
                FileInfo tex = new FileInfo(tex_path);
                Console.WriteLine("Gefunden: " + tex.Name.Replace(".xnb", "") + " In Pfad: " + tex_path.Replace(".xnb", ""));
                pathDictionary.Add(tex.Name.Replace(".xnb", ""), tex_path.Replace(".xnb", ""));
            }
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
