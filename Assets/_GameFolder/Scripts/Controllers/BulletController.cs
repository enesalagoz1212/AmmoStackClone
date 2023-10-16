using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;
using AmmoStackClone.BulletCollisions;
using DG.Tweening;

namespace AmmoStackClone.Controllers
{
	public class BulletController : MonoBehaviour
	{

		private LevelManager _levelManager;
		private InputManager _inputManager;
		private BulletCollisionHandler _bulletCollisionHandler;
		private Vector3 _initialPosition;

		private List<GameObject> collidedBullets = new List<GameObject>();
		private float zSpacing = 0.8f;

		public void Initialize(InputManager inputManager, LevelManager levelManager, BulletCollisionHandler bulletCollisionHandler)
		{
			_inputManager = inputManager;
			_levelManager = levelManager;
			_bulletCollisionHandler = bulletCollisionHandler;


		}

		private void OnEnable()
		{
			GameManager.OnGameStarted += OnGameStart;
			GameManager.OnGameReset += OnGameReset;
			GameManager.OnGameEnd += OnGameEnd;
		}

		private void OnDisable()
		{
			GameManager.OnGameStarted -= OnGameStart;
			GameManager.OnGameReset -= OnGameReset;
			GameManager.OnGameEnd -= OnGameEnd;

		}


		private void OnGameStart()
		{

		}

		private void OnGameReset()
		{
			Debug.Log("collidedBullets Count: " + collidedBullets.Count);
			collidedBullets.Clear();
			Debug.Log("collidedBullets Count: " + collidedBullets.Count);

			Vector3 scale = new Vector3(0.5f, 3f, 0.5f);
			transform.localScale = scale;


		}

		private void OnGameEnd(bool isSuccessful)
		{
			if (!isSuccessful)
			{
				DOVirtual.DelayedCall(1f, () =>
				{
					_initialPosition = new Vector3(0.23f, 0.78f, -1.81f);
					transform.localPosition= _initialPosition;
				});
			
			}
		}

		private void Start()
		{

		}



		private void Update()
		{

			if (collidedBullets.Count > 0)
			{
				float mainX = transform.position.x;
				float currentY = transform.position.y;
				float currentZ = transform.position.z;
				for (var i = 0; i < collidedBullets.Count; i++)
				{
					var bulletTransform = collidedBullets[i].transform;
					var bulletPosX = bulletTransform.position.x;

					var targetX = Mathf.Lerp(bulletPosX, mainX, Time.deltaTime * 16f);
					float newZ = currentZ + (i + 0.8f) * zSpacing;
					bulletTransform.position = new Vector3(targetX, currentY, newZ);

					mainX = bulletPosX;
				}
			}

			return;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Bullet"))
			{
				GameObject bullet = other.gameObject;
				collidedBullets.Add(bullet);

				Vector3 scale = new Vector3(0.5f, 3f, 0.5f);
				other.transform.localScale = scale;


				other.tag = "Player";

			}
			else if (other.CompareTag("Finish"))
			{
				GameManager.Instance.EndGame(true);
			}
		}
	}
}

