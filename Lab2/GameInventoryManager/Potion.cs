using GameInventoryManager;
using GameInventoryManager.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager
{
    public class Potion : GameItem, IIsUsable
    {
        public string Effect { get; set; }
        public int PowerLevel { get; set; }
        
        public Potion (string name, string description, int weight, int maxstacksize, string effect, int powerlevel) : base (name, description, weight)
        {
            Effect = effect;
            PowerLevel = powerlevel;
        }
        public string Use(InventoryManager inventory) 
        {
            inventory.RemoveItem(this);
            return $"You used potion '{Name}' with '{Effect} effect and level: {PowerLevel}";
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Effec: {Effect}, PowerLevel: {PowerLevel}";
        }        
    }
}
