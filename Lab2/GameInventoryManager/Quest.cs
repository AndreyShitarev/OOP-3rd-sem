using GameInventoryManager.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager
{
    class QuestItem : GameItem, IInfoAbout // + show quest info(), stage of quest, level of quest
    {
        public int LevelOfQuest { get; set; }
        public string PartOf {  get; set; }

        public QuestItem (string name, string description, int weight, string partof , int levelofquest) : base(name, description, weight)
        {  
            LevelOfQuest = levelofquest;
            PartOf = partof;
        }

        public string QuestInfo
        {
            get
            {
                return $"This quest is associated with quest: {PartOf}";
            }
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Assosiated with: {PartOf}, Reccomended level of player {LevelOfQuest}";
        }
    }
}
