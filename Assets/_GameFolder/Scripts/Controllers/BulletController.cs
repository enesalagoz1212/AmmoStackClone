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
		private float zSpacing = 0.5f;

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


		}


		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Bullet"))
			{
				collidedBullets.Add(other.gameObject);

				collidedBullets.Sort((a, b) => a.transform.position.z.CompareTo(b.transform.position.z));
				SortingOnZ();

				foreach (GameObject item in collidedBullets)
				{
					Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, item.transform.position.z);
					item.transform.position = newPosition;
				}

				Vector3 scale = new Vector3(6f, 6f, 6f);
				other.transform.localScale = scale;

				other.transform.SetParent(transform);
				other.tag = "Player";
			}

		}

		private void SortingOnZ()
		{
			float currentZ = transform.position.z;
			for (int i = 0; i < collidedBullets.Count; i++)
			{
				float newZ = currentZ + i * zSpacing;
				Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, newZ);
				collidedBullets[i].transform.position = newPosition;
			}
		}
	}
}

