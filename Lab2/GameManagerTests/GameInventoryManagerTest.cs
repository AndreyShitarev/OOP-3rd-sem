using GameInventoryManager;
using GameInventoryManager.Interface;
using System;
using System.Linq;
using Xunit; 

namespace InventoryTests
{
    public class InventoryTests
    {
        private InventoryManager _manager;
        private ICombinableItem _combiner;

        public InventoryTests()
        {
            _combiner = new ItemCombiner();
            _manager = new InventoryManager(100, _combiner);
        }

        [Fact]
        public void Test_AddItem_ShouldIncreaseCountAndWeight()
        {
            var sword = new Weapon("Sword", "Sharp", 10, 50, 100, "Steel");
            _manager.AddItem(sword);
            Assert.Single(_manager.Items); 
        }

        [Fact]
        public void Test_EquipWeapon_ShouldSetIsEquipped()
        {
            var sword = new Weapon("Sword", "Sharp", 10, 50, 100, "Steel");
            _manager.AddItem(sword);

            _manager.EquipItem(sword);

            Assert.True(sword.IsEquiped);
        }

        [Fact]
        public void Test_EquipNewWeapon_ShouldUnequipOldOne()
        {
            var sword1 = new Weapon("Sword1", "...", 10, 50, 100, "Steel");
            var sword2 = new Weapon("Sword2", "...", 10, 60, 100, "Iron");
            _manager.AddItem(sword1);
            _manager.AddItem(sword2);

            _manager.EquipItem(sword1);
            Assert.True(sword1.IsEquiped);

            _manager.EquipItem(sword2);

            Assert.False(sword1.IsEquiped); 
            Assert.True(sword2.IsEquiped);  
        }

        [Fact]
        public void Test_UsePotion_ShouldRemoveFromInventory()
        {
            var potion = new Potion("Health", "Heals", 1, 1, "Heal", 10);
            _manager.AddItem(potion);

            potion.Use(_manager);

            Assert.DoesNotContain(potion, _manager.Items);
            Assert.Empty(_manager.Items);
        }

        [Fact]
        public void Test_CombineItems_ShouldCreateImprovedVersion()
        {
            var w1 = new Weapon("Axe", "Basic", 10, 20, 50, "Wood");
            var w2 = new Weapon("Axe", "Basic", 10, 20, 50, "Wood");
            _manager.AddItem(w1);
            _manager.AddItem(w2);

            var newWeapon = _manager.CombineItems(w1, w2) as Weapon;

            Assert.NotNull(newWeapon);
            Assert.Equal("Improved Axe", newWeapon.Name);
            Assert.Equal(30, newWeapon.Damage);
            Assert.Single(_manager.Items);
        }

        [Fact]
        public void Test_Overweight_ShouldThrowException()
        {
            var heavyItem = new Weapon("Hammer", "Heavy", 101, 100, 100, "Rock");
            Assert.Throws<InvalidOperationException>(() => _manager.AddItem(heavyItem));
        }
    }
}