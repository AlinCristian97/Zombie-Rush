using UnityEngine;

namespace Weapon
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private AmmoSlot[] _ammoSlots;
        
        [System.Serializable]
        private class AmmoSlot
        {
            public AmmoType AmmoType;
            public int AmmoAmount;
        }

        // public int GetCurrentAmmo()
        // {
        //     return AmmoAmount;
        // }

        public void ReduceCurrentAmmo()
        {
            // AmmoAmount--;
        }
    }
}
