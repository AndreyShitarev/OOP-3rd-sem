using GameInventoryManager;
using GameInventoryManager.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager
{
    public class Weapon : GameItem, IIsEquipable
    {
        public bool IsEquiped { get; set;  } = false;
        public double Damage { get; set; }
        public int WeaponDurability { get; set; }
        public string? WeaponMaterial { get; set; }

        public Weapon(string name, string description, int weight, double damage, int weapondurability, string? material ) : base (name, description, weight)
        {
            Damage = damage;
            WeaponDurability = weapondurability;
            WeaponMaterial = material;
        }
        public string Equip(InventoryManager inventory)
        {
            inventory.EquipItem(this);
            return $"Weapone '{ Name}' equipped. Damage: {Damage}";
        }

        public string UnEquip(InventoryManager inventory)
        {
            inventory.UnequipItem(this);
            return $"Weapone '{Name}' unequipped";
        }

        public string Attack()
        {
            if (!IsEquiped)
            {
                return $"Weapon '{Name}' isn't equipped, you can't attack with it";
            }
            if (WeaponDurability <= 0)
            {
                return $"Weapon '{Name}' is broken. Repare it, to attack.";
            }

            WeaponDurability -= 1;

            if (WeaponDurability <= 0)
            {
                return $"Weapone '{Name}' just have been broken, repare it to continue fight";
            }
            return $"You attacked enemy with weapon '{Name}' for damage: {Damage}, WeaponDurability left: {WeaponDurability}";
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
            return base.GetInfo() + $"Damage: {Damage}, durability: {WeaponDurability}, material: {WeaponMaterial}";
        }
    }
}
