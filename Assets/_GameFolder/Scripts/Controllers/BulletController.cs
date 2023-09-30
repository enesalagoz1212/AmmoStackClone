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

		public Material[] materials = new Material[4];
		public void Initialize(InputManager inputManager, LevelManager levelManager)
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
			if (other.CompareTag("Bullet"))
			{
				other.transform.SetParent(transform);
				other.tag = "Player";
			}


			if (other.CompareTag("Red") || other.CompareTag("Blue") || other.CompareTag("Green") || other.CompareTag("Yellow"))
			{
				ChangeColorByTag(other.tag);
			}
		}

		private void ChangeColorByTag(string tag)
		{
			Material newMaterial = null;

			// Tag'e göre doðru malzemeyi seç
			switch (tag)
			{
				case "blue":
					newMaterial = materials[0]; // BlueMaterial, mavi renk malzemesini temsil eder
					break;
				case "yellow":
					newMaterial = materials[1]; // YellowMaterial, sarý renk malzemesini temsil eder
					break;
				case "red":
					newMaterial = materials[2]; // RedMaterial, kýrmýzý renk malzemesini temsil eder
					break;
				case "green":
					newMaterial = materials[3]; // GreenMaterial, yeþil renk malzemesini temsil eder
					break;

			}

			// Malzemeyi deðiþtir
			if (newMaterial != null)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.material = newMaterial;
				}
			}
		}
	}
}

