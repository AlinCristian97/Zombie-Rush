using System;
using UnityEngine;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton

        private static Inventory _instance;
        
        public static Inventory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Inventory>();
                }
                
                return _instance;
            }
        }

        #endregion
        
        [field:Header("Bullets")]
        [SerializeField] private int _maxBulletsAmount;
        [SerializeField] private int _startBulletsAmount;
        public int CurrentBulletsAmount { get; private set; }

        [field:Header("Shells")]
        [SerializeField] private int _maxShellsAmount;
        [SerializeField] private int _startShellsAmount;
        public int CurrentShellsAmount { get; private set; }

        private void Awake()
        {
            InitializeBulletsAmount();
            InitializeShellsAmount();
        }

        private void InitializeBulletsAmount()
        {
            if (_startBulletsAmount >= _maxBulletsAmount)
            {
                _startBulletsAmount = _maxBulletsAmount;
            }

            CurrentBulletsAmount = _startBulletsAmount;
        }

        private void InitializeShellsAmount()
        {
            if (_startShellsAmount >= _maxShellsAmount)
            {
                _startShellsAmount = _maxShellsAmount;
            }

            CurrentShellsAmount = _startShellsAmount;
        }

        public void DecreaseBulletsAmount(int amount)
        {
            CurrentBulletsAmount -= amount;
            if (CurrentBulletsAmount <= 0)
            {
                Debug.Log("Out of Bullets in inventory");
                CurrentBulletsAmount = 0;
            }
        }

        public void IncreaseBulletsAmount(int amount)
        {
            CurrentBulletsAmount += amount;
            if (CurrentBulletsAmount >= _maxBulletsAmount)
            {
                Debug.Log("Reached max number of Bullets in inventory");
                CurrentBulletsAmount = _maxBulletsAmount;
            }
        }
        
        public void DecreaseShellsAmount(int amount)
        {
            CurrentShellsAmount -= amount;
            if (CurrentShellsAmount <= 0)
            {
                Debug.Log("Out of Shells in inventory");
                CurrentShellsAmount = 0;
            }
        }
        
        public void IncreaseShellsAmount(int amount)
        {
            CurrentShellsAmount += amount;
            if (CurrentShellsAmount >= _maxShellsAmount)
            {
                Debug.Log("Reached max number of Shells in inventory");
                CurrentShellsAmount = _maxShellsAmount;
            }
        }
    }
}
