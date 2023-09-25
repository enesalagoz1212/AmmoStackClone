using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmmoStackClone.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }
        public Transform CurrentBulletTransform { get; private set; }
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
            SpawnBullet();
		}

        public void SpawnBullet()
		{
            var bulletObject = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity, bullets);
            CurrentBulletTransform = bulletObject.transform;
		}

    }

}
