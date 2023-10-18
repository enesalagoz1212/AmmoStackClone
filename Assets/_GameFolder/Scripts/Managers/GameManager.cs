using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Controllers;
using AmmoStackClone.BulletCollisions;
using DG.Tweening;

namespace AmmoStackClone.Managers
{
	public enum GameState
	{
		Start = 0,
		Playing = 1,
		End = 2,
		Reset = 3,
	}
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance { get; private set; }
		public GameState GameState { get; set; }

		public static Action OnGameStarted;
		public static Action<bool> OnGameEnd;
		public static Action OnGameReset;

		[SerializeField] private InputManager inputManager;
		[SerializeField] private BulletController bulletController;
		[SerializeField] private UIManager uiManager;
		[SerializeField] private CameraController cameraController;
		[SerializeField] private LevelManager levelManager;
		[SerializeField] private PlayerController playerController;
		[SerializeField] private BulletCollisionHandler bulletCollisionHandler;
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
		void Start()
		{
			GameInitialize();
		}

		private void GameInitialize()
		{
			levelManager.Initialize();
			inputManager.Initialize(playerController);
			bulletController.Initialize(inputManager, levelManager, bulletCollisionHandler);
			uiManager.Initialize(inputManager);
			bulletCollisionHandler.Initialize();
			playerController.Initialize(bulletController);

			OnGameStart();
		}
		void Update()
		{

		}

		private void OnGameStart()
		{
			ChangeState(GameState.Start);
		}

		public void EndGame(bool isSuccessful)
		{
			ChangeState(GameState.End);

			if (isSuccessful)
			{
				PlayerPrefsManager.CurrentLevel++;
			}
			else
			{

			}
		}

		public void ResetGame()
		{
			DOVirtual.DelayedCall(1f, () =>
			{
				ChangeState(GameState.Reset);

				DOVirtual.DelayedCall(3f, () =>
				{
					OnGameStart();
				});
			});
		}

		public void ChangeState(GameState gameState, bool isSuccessful = true)
		{
			GameState = gameState;

			Debug.Log($"Game State: {gameState}");

			switch (gameState)
			{
				case GameState.Start:
					OnGameStarted?.Invoke();
					break;
				case GameState.Playing:
					break;
				case GameState.End:
					OnGameEnd?.Invoke(isSuccessful);
					ResetGame();
					break;
				case GameState.Reset:
					OnGameReset?.Invoke();
					break;
			}
		}
	}
}