using System;
using General.Patterns.Observer;
using Player;
using UnityEngine;

namespace Weapon.Projectile
{
    public abstract class ProjectileContainer : MonoBehaviour
    {
        [SerializeField] protected int MaxProjectilesAmount = 30;
        protected int CurrentProjectilesAmount;
        public bool HasProjectiles => CurrentProjectilesAmount > 0;
        
        private void Awake()
        {
            InitializeContainer();
        }

        public void DecreaseProjectilesAmount()
        {
            CurrentProjectilesAmount--;
            
            if (CurrentProjectilesAmount <= 0)
            {
                CurrentProjectilesAmount = 0;
            }
        }

        private void InitializeContainer()
        {
            CurrentProjectilesAmount = MaxProjectilesAmount;
        }

        #region Unity Animation Triggers

        

        #endregion
        protected abstract void ReloadContainer();
    }
}