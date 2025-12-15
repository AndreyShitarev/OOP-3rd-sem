using System;
using System.Linq;
using GameInventoryManager.Interface;


/*
 * class that transforms 2 identical items into 1 with better characteristics
 * into 1 with better characteristics
 */


namespace GameInventoryManager
{
    public class ItemCombiner : ICombinableItem 
    {
        public bool IsCombined(GameItem item1, GameItem item2)
        {
            return item1.Name == item2.Name && !(item1 is QuestItem); //  the same item and not Quest item          
        }

        public GameItem? Combine(GameItem item1, GameItem item2)
        {
            if (!IsCombined(item1, item2))
            {
                return null;
            }

            if (item1 is Weapon weapon1 && item2 is Weapon weapon2)
            {
                var newWeapon = new Weapon(
                    name: $"Improved {weapon1.Name}", 
                    description: weapon1.Description,
                    weight: weapon1.Weight,
                    damage: weapon1.Damage * 1.5,
                    weapondurability: weapon1.WeaponDurability + weapon2.WeaponDurability, 
                    material: weapon1.WeaponMaterial
                );

                newWeapon.IsEquiped = weapon1.IsEquiped;

                return newWeapon;
            }


            else if (item1 is Armor armor1 && item2 is Armor armor2)
            {
                var newArmor = new Armor(
                    name: $"Improved {armor1.Name}",
                    description: armor1.Description,
                    weight: armor1.Weight,
                    armordurabiity: armor1.ArmorDurability + 10,
                    protection: armor1.Protection + 10,
                    material: armor1.ArmorMaterial
                );
                
                newArmor.IsEquiped = armor1.IsEquiped;

                return newArmor;
            }

            return null;
        }
    }
}