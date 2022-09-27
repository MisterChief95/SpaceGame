using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Item/New Item", fileName = "NewItem")]
    public class Item : ScriptableObject
    {
        public string tag;
        public string itemName;
        public string description;
        public Sprite icon;
    }
}
