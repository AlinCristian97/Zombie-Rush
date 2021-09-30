using Player;
using UnityEngine;

namespace Weapon.Projectile
{
    public class BulletContainer : ProjectileContainer
    {
        protected override void ReloadContainer()
        {
            if (CurrentProjectilesAmount == MaxProjectilesAmount)
            {
                Debug.Log("Weapon ammo is full!");
            }
            else if (CurrentProjectilesAmount < MaxProjectilesAmount && Inventory.Instance.CurrentBulletsAmount > 0)
            {
                Debug.Log("Reloading...");
                //play reload animation & SFX
                int amountToAdd = MaxProjectilesAmount - CurrentProjectilesAmount;
                
                Inventory.Instance.DecreaseBulletsAmount(amountToAdd);
                Debug.Log("CurrentProjectilesAmount before reload: " + CurrentProjectilesAmount);
                CurrentProjectilesAmount += amountToAdd;
                Debug.Log("CurrentProjectilesAmount after reload: " + CurrentProjectilesAmount);
            }
        }
    }
}