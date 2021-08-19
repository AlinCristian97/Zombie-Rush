using UnityEngine;

namespace Weapon
{
    public class AmmoPickup : MonoBehaviour
    {
        [SerializeField] private int _ammoAmount = 5;
        [SerializeField] private AmmoType _ammoType;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<Ammo>().IncreaseCurrentAmmo(_ammoType, _ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}
