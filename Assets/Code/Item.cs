using System;
using UnityEngine;

namespace Code
{
    public class Tool: Item
    {
        
    }

    public class Inventory
    {
        public Item[] Items;

        public Inventory(int inventorySlots = 30)
        {
            Items = new Item[inventorySlots];
        }
    }
    
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 1)]
    public class Item: ScriptableObject
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name;

        /// <summary>
        /// What the object is.
        /// </summary>
        public string Description;
        
        /// <summary>
        /// How much the item is worth.
        /// </summary>
        public Money Value;
        
        /// <summary>
        /// What the item looks like.
        /// </summary>
        public Sprite Icon;
    }

    [CreateAssetMenu(fileName = "Powerup", menuName = "Items/Power Up", order = 1)]
    public class Powerup : Item
    {
        /// <summary>
        /// The number of minutes the powerup lasts.
        /// </summary>
        public int Duration;
    }

    public enum MoneyType
    {
        Diamonds,
        Emeralds,
        Rubies,
        Copper,
        Silver,
        Gold
    }
    
    [Serializable]
    public class Money
    {
        public MoneyType Type;
        public int Amount;
    }
}