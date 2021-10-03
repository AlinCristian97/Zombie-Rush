using UnityEngine;

namespace Weapon
{
    public class WeaponSwitcher : MonoBehaviour
    {
        [SerializeField] private int _currentWeapon;

        private void Start()
        {
            SetWeaponActive();
        }

        private void Update()
        {
            int previousWeapon = _currentWeapon;

            ProcessKeyInput();
            ProcessScrollWheelInput();

            if (previousWeapon != _currentWeapon)
            {
                SetWeaponActive();
            }
        }

        private void ProcessScrollWheelInput()
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                if (_currentWeapon >= transform.childCount - 1)
                {
                    _currentWeapon = 0;
                }
                else
                {
                    _currentWeapon++;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (_currentWeapon <= 0)
                {
                    _currentWeapon = transform.childCount - 1;
                }
                else
                {
                    _currentWeapon--;
                }
            }
        }

        private void ProcessKeyInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _currentWeapon = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _currentWeapon = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _currentWeapon = 2;
            }
        }

        private void SetWeaponActive()
        {
            int weaponIndex = 0;

            foreach (Transform weapon in transform)
            {
                weapon.gameObject.SetActive(weaponIndex == _currentWeapon);
                weaponIndex++;
            }
        }
    }
}
