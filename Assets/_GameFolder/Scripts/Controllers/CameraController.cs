using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Controllers
{
	public class CameraController : MonoBehaviour
	{


        public Transform target; // Kameran�n takip edece�i hedef (PlayerController'�n transformu)
        public float zOffset;
        public float xPosition;
        public float yPosition;

        void Update()
        {
            if (target != null)
            {
                
                    // Kameran�n X ve Y pozisyonlar�n� PlayerController'�n X ve Y pozisyonlar�na sabitlerken, Z pozisyonunu belirli bir mesafede tutma
                    Vector3 newPosition = new Vector3(xPosition, yPosition, target.position.z + zOffset);
                    transform.position = newPosition;
                
            }
        }

    }
}

