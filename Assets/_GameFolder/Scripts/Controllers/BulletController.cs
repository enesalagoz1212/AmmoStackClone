using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmmoStackClone.Controllers
{
    public class BulletController : MonoBehaviour
    {

        public float forwardSpeed;
        public Vector3 initialPosition;

		public void Initialize()
		{
            initialPosition = new Vector3(0f, 0.75f, 0f);
            transform.position = initialPosition;
		}
		void Start()
        {

        }


        void Update()
        {
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }
}

