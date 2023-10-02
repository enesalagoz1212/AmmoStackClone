using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmmoStackClone.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        public Transform bullets;
        public GameObject bulletPrefab;
        public Vector3 bulletSpawnPosition;
	
		private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void Initialize()
		{

		}

		private void OnEnable()
		{
            GameManager.OnGameStarted += OnGameStart;
		}

		private void OnDisable()
		{
            GameManager.OnGameStarted -= OnGameStart;
			
		}

     
        private void OnGameStart()
		{
            SpawnBullet(bulletSpawnPosition);
		}

        public void SpawnBullet(Vector3 offset)
		{
            Vector3 eulerRotation = new Vector3(270f, 0f, -90f);
            Quaternion rotation = Quaternion.Euler(eulerRotation);

            var bulletObject = Instantiate(bulletPrefab, offset, rotation, bullets);
           
		}

    }

}
