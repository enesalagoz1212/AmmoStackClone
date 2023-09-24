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

		public void Initialize(InputManager inputManager)
		{
			inputCanvas.Initialize(inputManager);
		}

		void Start()
		{

		}

		void Update()
		{

		}
	}
}

