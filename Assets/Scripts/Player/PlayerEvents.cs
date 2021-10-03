using System;
using UnityEngine;

namespace Player
{
    public class PlayerEvents : MonoBehaviour
    {
        public static event Action OnReloadButtonPressed;
        
        private void Update()
        {
            HandleReloadButtonPressed();
        }

        private void HandleReloadButtonPressed()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnReloadButtonPressed?.Invoke();
            }
        }
    }
}
