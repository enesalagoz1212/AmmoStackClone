using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;
using AmmoStackClone.BulletCollisions;

namespace AmmoStackClone.Controllers
{
	public class BulletController : MonoBehaviour
	{
		private LevelManager _levelManager;
		private InputManager _inputManager;
		public float forwardSpeed;
		public Vector3 initialPosition;

		private bool isAttachedToPlayer = false;
		public void Initialize(InputManager inputManager,LevelManager levelManager)
		{
			_inputManager = inputManager;
			_levelManager = levelManager;
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
			initialPosition = new Vector3(-1.29f, 0.7882054f, -1.81f);
			transform.position = initialPosition;

			
		}
		private void Start()
		{

		}


		private void Update()
		{
			switch (GameManager.Instance.GameState)
			{
				case GameState.Start:
					break;
				case GameState.Playing:
					transform.position += transform.right * forwardSpeed * Time.deltaTime;
					break;
				case GameState.End:
					break;
				case GameState.Reset:
					break;
				default:
					break;
			}

		}

		
			private void OnTriggerEnter(Collider other)
			{
				if (other.CompareTag("Bullet") && !isAttachedToPlayer)
				{
					isAttachedToPlayer = true;

					Transform playerTransform = other.transform;
					Transform bulletTransform = transform;
					bulletTransform.SetParent(playerTransform);

				
					Vector3 offset = playerTransform.right * (bulletTransform.localScale.z / 2f + 1f);
					bulletTransform.position = playerTransform.position + offset;

				}
			}
			
	}
}

