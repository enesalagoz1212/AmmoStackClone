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
		private int _currentLevel = 1;
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

		private void Start()
		{
			SpawnBullet(bulletSpawnPosition);
		}

		private void OnGameStart()
		{
			EnableLevel(_currentLevel);
			
		}

		private void OnGameEnd(bool isSuccessful)
		{
			if (!isSuccessful)
			{
				DOVirtual.DelayedCall(1f, () =>
				{
					CompleteLevel();
				});

			}
		}

		private void EnableLevel(int levelIndex)
		{
			GameObject level = levels.transform.Find("Level" + levelIndex).gameObject;
			if (level != null)
			{
				level.SetActive(true);
			}
		}

		private void DisableLevel(int levelIndex)
		{
			GameObject level = levels.transform.Find("Level" + levelIndex).gameObject;
			if (level != null)
			{
				level.SetActive(false);
			}
		}

		public void CompleteLevel()
		{
			DisableLevel(_currentLevel);
			_currentLevel++;
			EnableLevel(_currentLevel);
		}

		public void SpawnBullet(Vector3 offset)
		{
			Vector3 eulerRotation = new Vector3(270f, 0f, -90f);
			Quaternion rotation = Quaternion.Euler(eulerRotation);

			var bulletObject = Instantiate(bulletPrefab, offset, rotation, bullets);

		}

	}

}
