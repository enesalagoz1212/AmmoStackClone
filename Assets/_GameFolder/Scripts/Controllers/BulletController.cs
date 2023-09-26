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
					transform.Translate(Vector3.right * forwardSpeed * Time.deltaTime);
					break;
				case GameState.End:
					break;
				case GameState.Reset:
					break;
				default:
					break;
			}

		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Bullet"))
			{



				collision.gameObject.transform.localScale = transform.localScale;

				Vector3 offset = new Vector3(0, 0, 1);
				Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + offset;

				collision.gameObject.transform.parent = transform;

			
				collision.gameObject.transform.position = spawnPos;
				collision.gameObject.tag = "Untagged";
			}
		}
	}
}

