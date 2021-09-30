using UnityEngine;

namespace Weapon
{
    [System.Serializable]
    public class AmmoSlot
    {
        [field:SerializeField] public AmmoType AmmoType { get; private set; }
        [field: SerializeField] public int MaxAmmoAmount { get; private set; } = 30;
        public int CurrentAmmoAmount { get; private set; }

        public void IncreaseAmmoAmount(int amount)
        {
            CurrentAmmoAmount += amount;
            
            if (CurrentAmmoAmount >= MaxAmmoAmount)
            {
                CurrentAmmoAmount = MaxAmmoAmount;
                Debug.Log("Full ammo for " + AmmoType);
            }
        }
        
        public void DecreaseAmmoAmount(int amount)
        {
            CurrentAmmoAmount -= amount;
            
            if (CurrentAmmoAmount <= 0)
            {
                CurrentAmmoAmount = 0;
                Debug.Log("Out of ammo for " + AmmoType);
            }
        }
    }
}