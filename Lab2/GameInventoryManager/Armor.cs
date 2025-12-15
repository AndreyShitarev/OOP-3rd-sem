using GameInventoryManager;
using GameInventoryManager.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager
{
    public class Armor : GameItem, IIsEquipable// + armor Durability, + Protection, + armor Material
    {
        public bool IsEquiped { get; set; } = false;
        public int ArmorDurability { get; set; }
        public int Protection { get; set; }
        public string ArmorMaterial { get; set; }

        public Armor(string name, string description, int weight, int armordurabiity, int protection, string material) : base(name, description, weight)
        {
            ArmorDurability = armordurabiity;
            Protection = protection;
            ArmorMaterial = material;
        }

        public string Equip(InventoryManager inventory)
        {
            inventory.EquipItem(this);
            return $"Armor '{Name}' equipped, durability: {ArmorDurability}', protection points: {Protection}, material: {ArmorMaterial}";

        }

        public string UnEquip(InventoryManager inventory)
        {
            inventory.UnequipItem(this);
            return $"Armor '{Name}' unequipped, you lost: {Protection} protection points";
        }

        public string AbsorbDamage()
        {
            if (!IsEquiped)
            {
                return $"Armor '{Name}' isn't equiped, damage can't be absorbed";
            }
            if (ArmorDurability <= 0)
            {
                return $"Your armor '{Name}' is broken, it can't save you from damage";
            }

            ArmorDurability -= 1;
            if (ArmorDurability <= 0)
            {
                return $"Your armor '{Name}' has been broken by this damage";
            }
            return $"Your armor '{Name}' asorbed: {Protection} damage points, current durability: {ArmorDurability}";
        }

        public override string GetInfo()
        {
            if (IsEquiped)
            {
                return "Equipped now";
            }
            if (!IsEquiped)
            {
                return "Not equipped";
            }
            return base.GetInfo() + $"Durability: {ArmorDurability}, protection: {Protection}, material {ArmorMaterial}";
        }

    }
}
