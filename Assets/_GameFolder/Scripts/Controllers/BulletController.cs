using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Controllers
{
	public class BulletController : MonoBehaviour
	{
		private InputManager _inputManager;
		public float forwardSpeed;
		public Vector3 initialPosition;

		public void Initialize(InputManager inputManager)
		{
			_inputManager = inputManager;
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
			//initialPosition = new Vector3(0f, 0.75f, 0f);
			//transform.position = initialPosition;
		}
		void Start()
		{

		}


		void Update()
		{
			switch (GameManager.Instance.GameState)
			{
				case GameState.Start:
					break;
				case GameState.Playing:
					transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
					break;
				case GameState.End:
					break;
				case GameState.Reset:
					break;
				default:
					break;
			}
			
		}
	}
}

