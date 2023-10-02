using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Controllers
{
	public class CameraController : MonoBehaviour
	{
		public Transform target;
		public float zOffset;
		public float xPosition;
		public float yPosition;

		void Update()
		{
			if (target != null)
			{
				Vector3 newPosition = new Vector3(xPosition, yPosition, target.position.z + zOffset);
				transform.position = newPosition;
			}
		}

	}
}

