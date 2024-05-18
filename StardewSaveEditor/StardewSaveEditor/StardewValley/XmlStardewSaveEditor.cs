using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace StardewSaveEditor.StardewValley
{
    internal class XmlStardewSaveEditor
    {
        string strSaveName;
        XmlDocument xtSave = new XmlDocument();
        XmlDocument xtGameInfo = new XmlDocument();
        public XmlStardewSaveEditor(string path)
        {
            //TODO : Verifier si le fichier xml est bien le fichiere de sauvegarde de stardew valley
            strSaveName = new DirectoryInfo(path).Name;
            string fileGameInfo = "SaveGameInfo";

            xtSave.Load(new FileStream(Path.Combine(path, strSaveName), FileMode.Open));
            xtGameInfo.Load(new FileStream(Path.Combine(path, fileGameInfo), FileMode.Open));
        }

        public XmlNode getPlayerNode()
        {
            return xtSave.SelectSingleNode("/SaveGame/player");
        }

        public string getPlayerName()
        {
            return xtSave.SelectSingleNode("/SaveGame/player/name").InnerText;
        }

        public XmlNodeList getFarmers()
        {
            return xtSave.SelectNodes("/SaveGame/farmhands/Farmer");
        }

        public void ChangeSaveOwner(XmlNode newOwner)
        {
            XmlNode oldOwner = getPlayerNode();
            XmlTools.ExchangeNodeContent(xtSave, newOwner, oldOwner);
        }
        public void ChangeSaveOwner(int idOwner)
        {
            XmlNode oldOwner = getPlayerNode();
            XmlNode newOwner = getFarmers()[idOwner];
            XmlTools.ExchangeNodeContent(xtSave, newOwner, oldOwner);
        }

        public void Save(string path)
        {
            string strDirPath = Path.Combine(path, strSaveName);
            if (!Directory.Exists(strDirPath)){
               Directory.CreateDirectory(strDirPath);
                string strSavePath =  Path.Combine(strDirPath, strSaveName);
                string strGameInfoPath = Path.Combine(strDirPath, "SaveGameInfo");

                xtSave.Save(strSavePath);
                xtGameInfo.Save(strGameInfoPath);
            }
        }
    }
}
