using System.Collections.Generic;

namespace Project.GamePlay
{
    public class PlayerInventory
    {
        private static List<string> _activeInventory = new List<string>();
        private static List<string> _usedItems = new List<string>();

        public static void AddItemToInvetory(string value)
        {
            if (_activeInventory.Contains(value)) return;
            _activeInventory.Add(value);
        }

        public static bool CanUseItem(string value)
        {
            return _activeInventory.Contains(value) && !_usedItems.Contains(value);
        }

        public static void UseItem(string value)
        {
            if(CanUseItem(value))
                _usedItems.Add(value);
        }

        public static bool CanSpawnItem(string value)
        {
            return !_activeInventory.Contains(value) && !_usedItems.Contains(value);
        }
    }
}
