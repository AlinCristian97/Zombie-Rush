using UnityEngine;

namespace Loot.Projectiles
{
    public abstract class ProjectilesLoot : MonoBehaviour
    {
        [field:SerializeField] protected int ProjectilesAmount { get; private set; } = 30;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                AddProjectilesToInventory();
                Destroy(gameObject);
            }
        }

        protected abstract void AddProjectilesToInventory();
    }
}
