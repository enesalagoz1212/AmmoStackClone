using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Controllers
{
	public class PlayerController : MonoBehaviour
	{		
		public float moveSpeed;
		public float forwardSpeed;
		public void Initialize()
		{

		}


		void Update()
		{
			switch (GameManager.Instance.GameState)
			{
				case GameState.Start:
					break;
				case GameState.Playing:
					transform.position += transform.forward * forwardSpeed * Time.deltaTime;
					break;
				case GameState.End:
					break;
				case GameState.Reset:
					break;
				default:
					break;
			}
		}

		public void MoveHorizontal(float horizontalMovement)
		{
			Vector3 currentPosition = transform.position;
			currentPosition.x += horizontalMovement;
			float minX = -4.2f; 
			float maxX = 3.4f;  

			currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
			transform.position = currentPosition;
		}
	}
}
