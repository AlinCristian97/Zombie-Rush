using System;
using General;
using UnityEngine;

namespace Player
{
    public class PlayerEvents : MonoBehaviour
    {
        public static event Action OnReloadButtonPressed;
        public static event Action OnPlayerDied;
        public static event Action OnPlayerCompletedMission;

        private static int _killCount;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Update()
        {
            HandleReloadButtonPressed();
            HandlePlayerDied();
            HandlePlayerCompletedMission();
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

        private void HandlePlayerCompletedMission()
        {
            if (_killCount >= 2)
            {
                OnPlayerCompletedMission?.Invoke();
            }
        }

        public static void IncrementKillCount()
        {
            _killCount++;
            Debug.Log("Killcount: " + _killCount);
        }
    }
}
