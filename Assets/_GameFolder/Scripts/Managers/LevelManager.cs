using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

namespace AmmoStackClone.Managers
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager Instance { get; private set; }

		public Transform bullets;
		public GameObject bulletPrefab;
		public Vector3 bulletSpawnPosition;

		public GameObject levels;
		private int _currentLevelIndex = 0;
		public GameObject[] levelPrefabs;

		private GameObject currentLevel;

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
			GameManager.OnGameEnd += OnGameEnd;
		}

		private void OnDisable()
		{
			GameManager.OnGameStarted -= OnGameStart;
			GameManager.OnGameEnd -= OnGameEnd;

		}

		private void OnGameStart()
		{
			if (currentLevel != null)
			{
				Destroy(currentLevel);
			}
			CreateNextLevel();
			//SpawnBullet(bulletSpawnPosition);
		}

		private void OnGameEnd(bool isSuccessful)
		{
			if (isSuccessful)
			{
				CreateNextLevel(); 
			}
		}

		public void CreateNextLevel()
		{
			if (currentLevel != null)
			{
				Destroy(currentLevel);
			}

			if (_currentLevelIndex < levelPrefabs.Length)
			{
				GameObject nextLevelPrefab = levelPrefabs[_currentLevelIndex];
				currentLevel = Instantiate(nextLevelPrefab, levels.transform);
				_currentLevelIndex++;
			}
			else
			{
				GameManager.Instance.EndGame(true);
			}
		}



		//public void SpawnBullet(Vector3 offset)
		//{
		//	Vector3 eulerRotation = new Vector3(270f, 0f, -90f);
		//	Quaternion rotation = Quaternion.Euler(eulerRotation);

		//	var bulletObject = Instantiate(bulletPrefab, offset, rotation, bullets);

		//}

	}

}
