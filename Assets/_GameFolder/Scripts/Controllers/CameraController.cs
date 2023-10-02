using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Controllers
{
	public class CameraController : MonoBehaviour
	{


        public Transform target; // Kameranýn takip edeceði hedef (PlayerController'ýn transformu)
        public float zOffset;
        public float xPosition;
        public float yPosition;

        void Update()
        {
            if (target != null)
            {
                
                    // Kameranýn X ve Y pozisyonlarýný PlayerController'ýn X ve Y pozisyonlarýna sabitlerken, Z pozisyonunu belirli bir mesafede tutma
                    Vector3 newPosition = new Vector3(xPosition, yPosition, target.position.z + zOffset);
                    transform.position = newPosition;
                
            }
        }

    }
}

