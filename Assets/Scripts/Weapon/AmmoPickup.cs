using UnityEngine;

namespace Weapon
{
    public class AmmoPickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player did what players do");
                Destroy(gameObject);
            }
        }
    }
}
