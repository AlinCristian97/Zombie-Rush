using System;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace General.Patterns.Singleton
{
    public class SpawnManager : MonoBehaviour
    {
        #region Singleton

        private static SpawnManager _instance;
        
        public static SpawnManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SpawnManager>();
                }
                
                return _instance;
            }
        }

        #endregion
        
        private const float SPAWN_MIN_X = -110f;
        private const float SPAWN_MAX_X = 110f;
        private const float SPAWN_MIN_Z = -110f;
        private const float SPAWN_MAX_Z = 110f;

        [Header("Enemies")] 
        [SerializeField] private Transform _enemiesHolder;
        [SerializeField] private List<EnemyAI> _zombie1List;

        private void Start()
        {
            SpawnAllEnemies();
        }

        private void SpawnAllEnemies()
        {
            SpawnEnemiesFromList(_zombie1List);
        }

        private void SpawnEnemiesFromList(List<EnemyAI> listOfEnemies)
        {
            foreach (EnemyAI enemy in listOfEnemies)
            {
                EnemyAI instantiatedEnemy = Instantiate(enemy, _enemiesHolder);

                float minOffset = 0f;
                float maxOffset = 0f;
                var position = new Vector3(
                    Random.Range(SPAWN_MIN_X, SPAWN_MAX_X),
                    transform.position.y,
                    Random.Range(SPAWN_MIN_Z, SPAWN_MAX_Z));
                position += new Vector3(
                    Random.Range(minOffset, maxOffset),
                    0f,
                    Random.Range(minOffset, maxOffset));
                
                instantiatedEnemy.transform.position = position;
            }
        }
    }
}
