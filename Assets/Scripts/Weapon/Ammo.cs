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

        public int GetCurrentAmmo(AmmoType ammoType)
        {
            return GetAmmoSlot(ammoType).AmmoAmount;
        }

        public void ReduceCurrentAmmo(AmmoType ammoType)
        {
            GetAmmoSlot(ammoType).AmmoAmount--;
        }

        private AmmoSlot GetAmmoSlot(AmmoType ammoType)
        {
            foreach (AmmoSlot slot in _ammoSlots)
            {
                if (slot.AmmoType == ammoType)
                {
                    return slot;
                }
            }
            return null;
        }
    }
}
