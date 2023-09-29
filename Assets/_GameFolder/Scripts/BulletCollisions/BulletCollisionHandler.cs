using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmmoStackClone.BulletCollisions
{
	public class BulletCollisionHandler : MonoBehaviour
	{
		private bool isAttachedToPlayer = false;

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player") && !isAttachedToPlayer)
			{
				isAttachedToPlayer = true;

				Vector3 scale = new Vector3(6f, 6f, 6f);
				transform.localScale = scale;

				Vector3 playerPosition = other.transform.position;
				Vector3 newPosition = new Vector3(playerPosition.x, transform.position.y+0.15f, transform.position.z+0.3f);
				transform.position = newPosition;
			}
			
		}

	}
}

