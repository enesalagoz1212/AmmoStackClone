using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Controllers;

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

		[SerializeField] private InputManager inputManager;
		[SerializeField] private BulletController bulletController;
		[SerializeField] private UIManager uiManager;
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
			inputManager.Initialize();
			bulletController.Initialize();
			uiManager.Initialize(inputManager);
			OnGameStart();
		}
		void Update()
		{

		}

		private void OnGameStart()
		{
			GameState = GameState.Start;
		}

		public void ChangeState(GameState gameState)
		{
			GameState = gameState;
		}
	}
}

