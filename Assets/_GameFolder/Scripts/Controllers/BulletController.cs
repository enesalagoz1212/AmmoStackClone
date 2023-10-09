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
		private BulletCollisionHandler _bulletCollisionHandler;
		public Vector3 initialPosition;

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

			if (collidedBullets.Count > 0)
			{
				float mainX = transform.position.x;
				float currentY= transform.position.y;
				float currentZ = transform.position.z;
				for (var i = 0; i < collidedBullets.Count; i++)
				{
					var bulletTransform = collidedBullets[i].transform;
					var bulletPosX = bulletTransform.position.x;

					var targetX = Mathf.Lerp(bulletPosX, mainX, Time.deltaTime * 10f);
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

				Debug.Log("collidedBullets listesinin eleman sayisi: " + collidedBullets.Count);

				Vector3 scale = new Vector3(0.5f, 3f, 0.5f);
				other.transform.localScale = scale;

				
				other.tag = "Player";	
			}
		}
	}
}

