using Player;
using UnityEngine;

namespace Weapon.Projectile
{
    public class ShellContainer : ProjectileContainer
    {
        protected override void ReloadContainer()
        {
            if (CurrentProjectilesAmount == MaxProjectilesAmount)
            {
                Debug.Log("Weapon ammo is full!");
            }
            else if (CurrentProjectilesAmount < MaxProjectilesAmount && Inventory.Instance.CurrentShellsAmount > 0)
            {
                //play reload animation & SFX
                int amountToAdd = MaxProjectilesAmount - CurrentProjectilesAmount;
                
                Inventory.Instance.DecreaseShellsAmount(amountToAdd);
                CurrentProjectilesAmount += amountToAdd;
            }
        }
    }
}