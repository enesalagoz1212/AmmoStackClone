using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Controllers;
using AmmoStackClone.BulletCollisions;

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
		public static Action OnGameEnd;
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
			bulletController.Initialize(inputManager,levelManager,bulletCollisionHandler);
			uiManager.Initialize(inputManager);
			//cameraController.Initialize();
			//bulletCollisionHandler.Initialize();
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

		public void ChangeState(GameState gameState)
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
					break;
				case GameState.Reset:
					break;
			}
		}
	}
}