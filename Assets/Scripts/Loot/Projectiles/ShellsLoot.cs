using Player;

namespace Loot.Projectiles
{
    public class ShellsLoot : ProjectilesLoot
    {
        protected override void AddProjectilesToInventory()
        {
            Inventory.Instance.IncreaseShellsAmount(ProjectilesAmount);
        }
    }
}