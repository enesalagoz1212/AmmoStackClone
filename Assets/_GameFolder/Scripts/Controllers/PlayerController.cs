using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Controllers
{
	public class PlayerController : MonoBehaviour
	{
		private BulletController _bulletController;
		public float forwardSpeed;
		public void Initialize(BulletController bulletController)
		{
			_bulletController = bulletController;
		}


		void Update()
		{
			switch (GameManager.Instance.GameState)
			{
				case GameState.Start:
					break;
				case GameState.Playing:
					MoveForward();
					break;
				case GameState.End:
					break;
				case GameState.Reset:
					break;
				default:
					break;
			}
		}

		public void MoveForward()
		{
			transform.position += transform.forward * forwardSpeed * Time.deltaTime;
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

