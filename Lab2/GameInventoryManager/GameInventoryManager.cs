using GameInventoryManager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameInventoryManager
{
    public class InventoryManager
    {

        private readonly List<GameItem> items;  // нельзя вызывать список из любой части программы и работать с ним в обход 
        public IReadOnlyCollection<GameItem> Items => items.AsReadOnly(); // без коллекции пришлось бы сделать список публичным ждя работы чс ним

        public ICombinableItem combiner;

        public InventoryManager(int maxWeight, ICombinableItem combiner)
        {
            items = new List<GameItem>();
            combiner = combiner; // для соблюдения принципа Dependency Inversion
        }

        public void AddItem(GameItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(GameItem item)
        {
            items.Remove(item);
        }

        public void EquipItem(IIsEquipable EquipingItem)
        {
            foreach (var item in Items) // снимаем если что-то уже экипировано
            {
                if (item is IIsEquipable currentEquipped)
                {
                    if (currentEquipped.IsEquiped && currentEquipped != EquipingItem)
                    {
                        currentEquipped.IsEquiped = false; 
                    }
                }
            }
            EquipingItem.IsEquiped = true;
        }

        public void UnequipItem(IIsEquipable item)
        {
            item.IsEquiped = false;
        }
        public string UseItem(IIsUsable item)
        {
            return item.Use(this);
        }

        public GameItem CombineItems(GameItem item1, GameItem item2)
        {
            if (combiner.IsCombined(item1, item2))
            {
                var newItem = combiner.Combine(item1, item2);

                if (newItem != null)
                {
                    RemoveItem(item1);
                    RemoveItem(item2);
                    AddItem(newItem);
                    return newItem;
                }
            }

            throw new InvalidOperationException("You cant combine this items");
        }

        public string GetInventoryStatus()
        {
            string info = ""; 
            foreach (var item in items)
            {
                info += item.GetInfo() + "\n"; 
            }
            return info;
        }
    }
}
