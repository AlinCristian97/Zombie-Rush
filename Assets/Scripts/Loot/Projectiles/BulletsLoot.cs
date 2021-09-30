using Player;

namespace Loot.Projectiles
{
    public class BulletsLoot : ProjectilesLoot
    {
        protected override void AddProjectilesToInventory()
        {
            Inventory.Instance.IncreaseBulletsAmount(ProjectilesAmount);
        }
    }
}