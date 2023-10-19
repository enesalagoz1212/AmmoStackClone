using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Canvases;

namespace AmmoStackClone.Managers
{
	public class UIManager : MonoBehaviour
	{
		public static UIManager Instance { get; private set; }

		[SerializeField] private InputCanvas inputCanvas;
		[SerializeField] private GameCanvas gameCanvas;
		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public void Initialize(InputManager inputManager ,LevelManager levelManager)
		{
			inputCanvas.Initialize(inputManager);
			gameCanvas.Initialize(levelManager);
		}

		void Start()
		{

		}

		void Update()
		{

		}
	}
}

