using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ItemFactory
{
    public class ItemFactory : MonoBehaviour
    {
        #region Singleton
        public static ItemFactory instance;
        void Awake()
        {
            if (instance != null)
            {
                Debug.LogWarning("At least one instance of ItemFactory already running");
                return;
            }
            instance = this;
        }
        #endregion
        public Wood wood;
        public Food food;
        public Stone stone;
        public Pickaxe pickaxe;
        public Axe axe;
        public FishCane fishcane;
        public RadioPiece radio;

        public Item getItem(string type)
        {
            switch (type)
            {
                case "axe":
                    return Instantiate(axe);
                case "pickaxe":
                    return Instantiate(pickaxe);
                case "fishcane":
                    return Instantiate(fishcane);
                case "wood":
                    return Instantiate(wood);
                case "stone":
                    return Instantiate(stone);
                case "food":
                    return Instantiate(food);
                case "radioPiece":
                    return Instantiate(radio);
                default:
                    Debug.Log("INVALID ITEM TYPE");
                    return null;
            }
        }
    }
}
