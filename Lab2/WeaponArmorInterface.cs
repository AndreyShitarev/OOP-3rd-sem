using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager.Interface
{
    public interface IIsEquipable
    {
        bool IsEquiped { get; set; }
        string Equip(InventoryManager inventory);
        string UnEquip(InventoryManager inventory);

    }
}

