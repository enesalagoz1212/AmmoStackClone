using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;
using DG.Tweening;

namespace AmmoStackClone.Controllers
{
	public class PlayerController : MonoBehaviour
	{
		private BulletController _bulletController;

		private Vector3 _initialPosition;
		public float forwardSpeed;
		private bool _canMove = true;
		public void Initialize(BulletController bulletController)
		{
			_bulletController = bulletController;
			_initialPosition = transform.position;
		}

		private void OnEnable()
		{
			GameManager.OnGameEnd += OnGameEnd;
		}

		private void OnDisable()
		{
			GameManager.OnGameEnd -= OnGameEnd;

		}
		void Update()
		{
			switch (GameManager.Instance.GameState)
			{
				case GameState.Start:
					_canMove = false;
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

		private void OnGameEnd(bool isSuccessful)
		{
			if (!isSuccessful)
			{
				DOVirtual.DelayedCall(1f, () =>
				{
					ResetPlayer();
				});
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

		public void ResetPlayer()
		{
			_initialPosition = new Vector3(0f, 0f, 0f);
			transform.localPosition = _initialPosition;
		}
	}
}

