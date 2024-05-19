using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
            strSaveName = new DirectoryInfo(path).Name;
            string fileGameInfo = "SaveGameInfo";

            FileStream fsSave = new FileStream(Path.Combine(path, strSaveName), FileMode.Open);
            FileStream fsGameInfo = new FileStream(Path.Combine(path, fileGameInfo), FileMode.Open);


            xtSave.Load(fsSave);
            xtGameInfo.Load(fsGameInfo);

            fsSave.Close();
            fsGameInfo.Close();
        }
        public string getSaveName()
        {
            return strSaveName;
        }

        public void Save(string path)
        {
            string strSavePath = Path.Combine(path, strSaveName);
            string strGameInfoPath = Path.Combine(path, "SaveGameInfo");
            //TODO : corriger le bug ou quand l'on recharge la sauvegarde alors que l'on vien de sauvegarder la prochaine sauvegarde ne peux pas modifier le fichier (déjà ouvert)
            xtSave.Save(strSavePath);
            xtGameInfo.Save(strGameInfoPath);

        }

        #region Accesseur des node
        public XmlNode getPlayerNode()
        {
            return xtSave.SelectSingleNode("/SaveGame/player");
        }

        public string getPlayerName()
        {
            return xtSave.SelectSingleNode("/SaveGame/player/name").InnerText;
        }
        public void setPlayerName(string newName)
        {
            xtSave.SelectSingleNode("/SaveGame/player/name").InnerText = newName;
        }

        public XmlNodeList getFarmers()
        {
            return xtSave.SelectNodes("/SaveGame/farmhands/Farmer");
        }

        #endregion

        public void ChangeSaveOwner(int idOwner)
        {
            XmlNode oldOwner = getPlayerNode();
            XmlNode newOwner = getFarmers()[idOwner];
            XmlTools.ExchangeNodeContent(xtSave, newOwner, oldOwner);
        }
    }
}
