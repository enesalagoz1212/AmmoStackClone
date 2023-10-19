using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using AmmoStackClone.Controllers;

namespace AmmoStackClone.Managers
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager Instance { get; private set; }
		private PlayerController _playerController;

		public GameObject levels;
		private int _currentLevelIndex;
		public GameObject[] levelPrefabs;

		private GameObject currentLevel;

		private float _firstPlatformPositionZ=0;
		private float _lastPlatformPositionZ=311;
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

		public void Initialize(PlayerController playerController)
		{
			_playerController = playerController;
			_currentLevelIndex = PlayerPrefsManager.CurrentLevel;
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
			CreateNextLevel();
		    levels.gameObject.SetActive(true);

			//SpawnBullet(bulletSpawnPosition);
		}

		private void OnGameEnd(bool isSuccessful)
		{
			DOVirtual.DelayedCall(1f, () =>
			{
				levels.gameObject.SetActive(false);
			});
		}

		public void CreateNextLevel()
		{
			if (currentLevel != null)
			{
				Destroy(currentLevel);
			}

			int levelPrefabsLength = levelPrefabs.Length;
			var _currentLevelIndex = (PlayerPrefsManager.CurrentLevel % levelPrefabsLength);

			if (_currentLevelIndex == 0)
			{
				_currentLevelIndex = levelPrefabsLength;
			}

			GameObject nextLevelPrefab = levelPrefabs[_currentLevelIndex - 1];
			currentLevel = Instantiate(nextLevelPrefab, levels.transform);
		}

		public float ReturnPlayerProgress()
		{
			Debug.Log("Return to player");
			var top = (_playerController.childTransform.position.z - _firstPlatformPositionZ);
			var bottom = (_lastPlatformPositionZ - _firstPlatformPositionZ);
			return top / bottom;
		}

		//public void SpawnBullet(Vector3 offset)
		//{
		//	Vector3 eulerRotation = new Vector3(270f, 0f, -90f);
		//	Quaternion rotation = Quaternion.Euler(eulerRotation);

		//	var bulletObject = Instantiate(bulletPrefab, offset, rotation, bullets);

		//}

	}

}
