using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager.Interface
{
    public interface IIsUsable
    {
        string Use(InventoryManager inventory);
    }
}