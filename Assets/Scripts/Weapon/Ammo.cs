using UnityEngine;

namespace Weapon
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] private AmmoSlot[] _ammoSlots;

        public int GetCurrentAmmo(AmmoType ammoType)
        {
            return GetAmmoSlot(ammoType).CurrentAmmoAmount;
        }

        public void ReduceCurrentAmmoAmount(AmmoType ammoType, int amountToReduce)
        {
            GetAmmoSlot(ammoType).DecreaseAmmoAmount(amountToReduce);
        }
        
        public void IncreaseCurrentAmmo(AmmoType ammoType, int amountToIncrease)
        {
            GetAmmoSlot(ammoType).IncreaseAmmoAmount(amountToIncrease);
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
