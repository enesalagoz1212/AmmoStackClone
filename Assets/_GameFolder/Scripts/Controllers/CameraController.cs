using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;
using DG.Tweening;

namespace AmmoStackClone.Controllers
{
	public class CameraController : MonoBehaviour
	{
		public Transform target;
		public float duration;
		public Vector3 initialPosition;
		public Quaternion initialRotation;
		public Vector3 targetPosition;
		public Quaternion targetRotation;

		private bool isMoving = false;

		private void OnEnable()
		{
			GameManager.OnGameStarted += OnGameStart;
			GameManager.OnGameReset += OnGameReset;
		}

		private void OnDisable()
		{
			GameManager.OnGameStarted -= OnGameStart;
			GameManager.OnGameReset -= OnGameReset;
		}

		private void OnGameStart()
		{

			if (!isMoving)
			{
				isMoving = true;
				transform.DOMove(targetPosition, duration).OnComplete(() => isMoving = false);
				transform.DORotate(targetRotation.eulerAngles, duration);
			}
		}

		private void OnGameReset()
		{
			DOVirtual.DelayedCall(3f, () =>
			{
				transform.position = initialPosition;
				transform.rotation = initialRotation;

			});



		}

		void Update()
		{
			if (!isMoving && target != null)
			{
				Vector3 newPosition = new Vector3(targetPosition.x, targetPosition.y, target.position.z + initialPosition.z);
				transform.position = newPosition;
			}
		}
	}
}

