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
				if (!HasBulletInFront(other))
				{
					collidedBullets.Add(other.gameObject);
				}

				int index = collidedBullets.FindIndex(item => item.CompareTag("Player"));
				if (index != -1)
				{
					collidedBullets.RemoveAt(index);
					collidedBullets.Insert(0, other.gameObject);
				}


				Vector3 scale = new Vector3(6f, 6f, 6f);
				other.transform.localScale = scale;


				Vector3 playerPosition = other.transform.position;
				Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, playerPosition.z + 0.5f);
				other.transform.position = newPosition;

				other.transform.SetParent(transform);
				other.tag = "Player";
			}

		}
		private bool HasBulletInFront(Collider other)
		{
			Collider[] collidersInFront = Physics.OverlapSphere(other.transform.position + Vector3.forward * 0.5f, 0.1f);
			foreach (Collider collider in collidersInFront)
			{
				if (collider.CompareTag("Bullet"))
				{
					return true;
				}
			}
			return false;
		}
	}
}

