using System;
using System.Collections.Generic;
using System.Text;

namespace GameInventoryManager.Interface
{
    public interface ICombinableItem
    {
        bool IsCombined(GameItem item1, GameItem item2); // can we combine 2 random items?
        GameItem? Combine(GameItem item1, GameItem item2); // if we can - combine
    }
}
