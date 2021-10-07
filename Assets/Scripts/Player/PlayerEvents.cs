using System;
using General;
using UnityEngine;

namespace Player
{
    public class PlayerEvents : MonoBehaviour
    {
        public static event Action OnReloadButtonPressed;
        public static event Action OnPlayerDied;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            HandleReloadButtonPressed();
            HandlePlayerDied();
        }

        private void HandleReloadButtonPressed()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnReloadButtonPressed?.Invoke();
            }
        }

        private void HandlePlayerDied()
        {
            if (_health.IsDead())
            {
                OnPlayerDied?.Invoke();
            }
        }
    }
}
