using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmmoStackClone.BulletCollisions
{
	public class BulletCollisionHandler : MonoBehaviour
	{
        private bool isAttachedToPlayer = false;
        private Transform mainBullet;
    

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !isAttachedToPlayer)
            {
                isAttachedToPlayer = true;

                Vector3 scale = other.transform.localScale;
                transform.localScale = scale;

                Transform playerTransform = other.transform;
                transform.SetParent(playerTransform);

                Vector3 offset = playerTransform.right * (scale.z / 2f + 1f);
                transform.position = playerTransform.position + offset;

                Rigidbody rb = GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                mainBullet = transform;
            }
            else if (other.CompareTag("Bullet") && mainBullet != null)
            {

                Vector3 scale = mainBullet.localScale;
                Vector3 offset = mainBullet.right * (scale.z / 2f + 1f);
                transform.position = mainBullet.position + offset;

                mainBullet = transform;
            }
        }

    }
}

