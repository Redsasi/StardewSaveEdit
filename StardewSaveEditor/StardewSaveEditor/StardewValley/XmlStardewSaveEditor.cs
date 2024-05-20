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
        XmlNamespaceManager nsmgSave;
        XmlNamespaceManager nsmgGameInfo;
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

            nsmgSave = new XmlNamespaceManager(xtSave.NameTable);
            nsmgGameInfo = new XmlNamespaceManager(xtGameInfo.NameTable);

            nsmgSave.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            nsmgGameInfo.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");

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
        #region Accesseur absolu
        // Player
        public XmlNode getOwnerNode()
        {
            return xtSave.SelectSingleNode("/SaveGame/player");
        }

        // Player Name
        public string getOwnerName()
        {
            return xtSave.SelectSingleNode("/SaveGame/player/name").InnerText;
        }
        public void seOwnerName(string newName)
        {
            xtSave.SelectSingleNode("/SaveGame/player/name").InnerText = newName;
        }

        // List Farmer
        public XmlNodeList getFarmers()
        {
            return xtSave.SelectNodes("/SaveGame/farmhands/Farmer");
        }
        public XmlNode getFarmLayout()
        {
            return xtSave.SelectSingleNode("/SaveGame/locations/GameLocation[@xsi:type='Farm']", nsmgSave);
        }
        public XmlNode getFarmHouse()
        {
            return xtSave.SelectSingleNode("/SaveGame/locations/GameLocation[@xsi:type='FarmHouse']", nsmgSave);
        }
        // List Cabins
        public XmlNodeList getCabins()
        {
            return getFarmLayout().SelectNodes("buildings/Building/indoors[@xsi:type='Cabin']", nsmgSave);
        }
        #endregion
        #region Accesseur relatif 
        public string getPlayerMultiplayerUniqueID(XmlNode nodePlayer)
        {
            return nodePlayer.SelectSingleNode("UniqueMultiplayerID").InnerText;
        }
        public void setPlayerMultiplayerUniqueID(XmlNode nodePlayer, string newID)
        {
            nodePlayer.SelectSingleNode("UniqueMultiplayerID").InnerText = newID;
        }

        public string getPlayerHomeLocation(XmlNode nodePlayer)
        {
            return nodePlayer.SelectSingleNode("homeLocation").InnerText;
        }

        public void setPlayerHomeLocation(XmlNode nodePlayer, string newHomeLocation)
        {
            nodePlayer.SelectSingleNode("homeLocation").InnerText = newHomeLocation;
        }

        #endregion
        #region Accesseur rechercher
        public XmlNode getHomeNodeByHomeLocation(string homeLocation)
        {
            if(homeLocation == "FarmHouse")
            {
                return getFarmHouse();
            }

            XmlNodeList cabins = getCabins();
            foreach(XmlNode cabin in cabins)
            {
                if(cabin.SelectSingleNode("uniqueName").InnerText == homeLocation)
                {
                    return cabin;
                }
            }
            return null;


        }
        #endregion
        #endregion
        public void ChangeHomesBetweenPlayer(XmlNode nodePlayerA,XmlNode nodePLayerB)
        {
            //get homes ref
            string homelocPlayerA = getPlayerHomeLocation(nodePlayerA);
            string homelocPlayerB = getPlayerHomeLocation(nodePLayerB);

            //change homes ref
            setPlayerHomeLocation(nodePlayerA, homelocPlayerB); 
            setPlayerHomeLocation(nodePLayerB, homelocPlayerA);

            //change homes content
            //Récuperer les bonne maison
            XmlNode homeA = getHomeNodeByHomeLocation(homelocPlayerA);
            XmlNode homeB = getHomeNodeByHomeLocation(homelocPlayerB);

            //characters
            XmlTools.ExchangeNodeContent(xtSave,homeA.SelectSingleNode("characters"), homeB.SelectSingleNode("characters"));
            //objects
            XmlTools.ExchangeNodeContent(xtSave, homeA.SelectSingleNode("objects"), homeB.SelectSingleNode("objects"));
            //furniture
            XmlTools.ExchangeNodeContent(xtSave, homeA.SelectSingleNode("furniture"), homeB.SelectSingleNode("furniture"));
            //fridge
            XmlTools.ExchangeNodeContent(xtSave, homeA.SelectSingleNode("fridge"), homeB.SelectSingleNode("fridge"));
        }

        public void ChangeSaveOwner(int idOwner)
        {
            XmlNode oldOwner = getOwnerNode();
            XmlNode newOwner = getFarmers()[idOwner];

            //change id between player
            string oldID = getPlayerMultiplayerUniqueID(oldOwner);
            setPlayerMultiplayerUniqueID(oldOwner, getPlayerMultiplayerUniqueID(newOwner));
            setPlayerMultiplayerUniqueID(newOwner, oldID);

            //TODO : Ajouter les event de choix déjà eu (Cave de la ferme [65])

            //Echanger les maison pour qu'il soit correctement agencer
            ChangeHomesBetweenPlayer(oldOwner, newOwner);

            XmlTools.ExchangeNodeContent(xtSave, newOwner, oldOwner);
        }
    }
}
