using System.Collections.Generic;

namespace Project.GamePlay
{
    public class PlayerInventory
    {
        private static List<string> _activeInventory = new List<string>();
        private static List<string> _usedItems = new List<string>();

        public static void AddItemToInventory(string value)
        {
            if (_activeInventory.Contains(value.ToLower())) return;
            _activeInventory.Add(value.ToLower());
        }

        public static bool CanUseItem(string value)
        {
            return _activeInventory.Contains(value.ToLower()) && !_usedItems.Contains(value.ToLower());
        }

        public static bool UseItem(string value)
        {
            if (CanUseItem(value.ToLower()))
            {
                _usedItems.Add(value.ToLower());
                return true;
            }
            return false;
        }

        public static bool CanSpawnItem(string value)
        {
            return !_activeInventory.Contains(value.ToLower()) && !_usedItems.Contains(value.ToLower());
        }
    }
}
