using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager
{
    public abstract class GameItem
    {
        public Guid ItemID { get; protected set; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public int Weight { get; private set; }
        
        protected GameItem(string name, string description, int weight)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("Item name can't be empty");

            ItemID = Guid.NewGuid(); // unique ID for each Item
            Name = name;
            Description = description;
            Weight = weight;
        }
        public virtual string GetInfo()
        {
            return $"{Name} (ID: {ItemID.ToString().Substring(0, 4)}...)\nWeight: {Weight}, Description: {Description}";
        }
    }
}
