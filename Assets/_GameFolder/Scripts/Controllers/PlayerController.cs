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
		private bool _canMove = true;
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
					_canMove = true;
					break;
				case GameState.End:
					_canMove = false;
					break;
				case GameState.Reset:
					break;
				default:
					break;
			}

			if (_canMove)
			{
				MoveForward();
			}
		}

		public void MoveForward()
		{
			transform.position += transform.forward * forwardSpeed * Time.deltaTime;
		}

		public void MoveHorizontal(float horizontalMovement)
		{
			if (!_canMove)
			{
				return;
			}

			Vector3 currentPosition = transform.position;
			currentPosition.x += horizontalMovement;
			float minX = -3.47f;
			float maxX = 3.61f;

			currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
			transform.position = currentPosition;

		}
	}
}

