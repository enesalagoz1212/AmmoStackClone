using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AmmoStackClone.Canvases
{
    public class EndCanvas : MonoBehaviour
    {
		public Transform target;
        void Start()
        {

        }

    
        void Update()
        {

        }


		private void OnTriggerEnter(Collider other)
		{
			

			if (other.CompareTag("Finish"))
			{
				transform.DOScale(Vector3.zero, 1f).OnComplete(() =>
				{
					Debug.Log("OnCompleted");
				});
				transform.DOMove(target.position, 1f);
			}
		}
	}
}

