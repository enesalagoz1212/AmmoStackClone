using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmmoStackClone.BulletCollisions
{
	public class BulletCollisionHandler : MonoBehaviour
	{

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {

                collision.gameObject.transform.localScale = transform.localScale;

                Vector3 offset = new Vector3(0, 0, 1);
                Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + offset;

                collision.gameObject.transform.parent = transform;


                collision.gameObject.transform.position = spawnPos;
                collision.gameObject.tag = "Untagged";
            }
        }

    }
}

