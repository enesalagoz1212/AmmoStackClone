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

		public Material[] bulletMaterials;

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

			if (other.CompareTag("Red") || other.CompareTag("Blue") || other.CompareTag("Yellow") || other.CompareTag("Green"))
			{
				int materialIndex = GetMaterialIndexByTag(other.tag);

				if (materialIndex != -1)
				{
					ChangeMaterial(bulletMaterials[materialIndex], gameObject);
				}

				foreach (GameObject bullet in collidedBullets)
				{
					// Liste elemanýnýn etiketini kontrol et ve uygun malzeme indeksini al
					if (bullet.CompareTag("Red") || bullet.CompareTag("Blue") || bullet.CompareTag("Yellow") || bullet.CompareTag("Green"))
					{
						int bulletMaterialIndex = GetMaterialIndexByTag(bullet.tag);

						if (bulletMaterialIndex != -1)
						{
							// Her bir liste elemanýnýn rengini deðiþtir
							ChangeMaterial(bulletMaterials[bulletMaterialIndex], bullet);
						}
					}
				}
			}
		}

		private void ChangeMaterial(Material newMaterial, GameObject bullet)
		{
			Renderer renderer = bullet.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.material = newMaterial;
			}
		}

		private int GetMaterialIndexByTag(string tag)
		{
			switch (tag)
			{
				case "Red":
					return 0;
				case "Blue":
					return 1;
				case "Yellow":
					return 2;
				case "Green":
					return 3;
				default:
					return -1; // tanimsiz tag
			}
		}


	}
}

