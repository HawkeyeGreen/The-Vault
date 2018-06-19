using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        private Dictionary<string, Texture2D> textureDictionary;
        private Dictionary<string, string> pathDictionary;
        static private TextureManager instance;
        static private ContentManager contentManager;

        private TextureManager(ContentManager content)
        {
            contentManager = content;
            textureDictionary = new Dictionary<string, Texture2D>();
            pathDictionary = new Dictionary<string, string>();

        }

        public void initialize(ContentManager content)
        {
            instance = new TextureManager(content);
        }

        public TextureManager getInstance()
        {
            if(instance == null)
            {
                throw new Exception("Der Texturemanager wurde noch nicht initialisiert. Stelle sicher, dass dieser Schritt vor dem Aufrufen der GetInstance-Methode erfolgt ist.");
            }
            else
            {
                return instance;
            }
        }

        public Texture2D GetTexture(string key)
        {
            if(textureDictionary.ContainsKey(key) == false)
            {
                
            }
            return textureDictionary[key];
        }

        /* Diese Methode lädt alle Texture-Pfade mit ihren Keys in das
         * pathDictionary. Hier für geht die Methode alle Ordner unterhalb von Content/textures durch und speichert für
         * alle .pngs unter ihren Namen den Pfad ab.
         */
        private void loadTexturePaths()
        {
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory + "/Content/textures";
            string[] level0_texs = Directory.GetFiles(baseFolder, "*.png");
            string[] level1 = Directory.GetDirectories(baseFolder);
            foreach(string folder in level1)
            {

            }
        }
    }
}
