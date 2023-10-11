using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AmmoStackClone.Controllers
{
    public class FinishController : MonoBehaviour
    {
        public Transform target;

        private void OnTriggerEnter(Collider other)
        {


            if (other.CompareTag("Player"))
            {
                other.gameObject.transform.DOScale(Vector3.zero, 1f).OnComplete(() =>
                {
                    Debug.Log("OnCompleted");
                });
                other.gameObject.transform.DOMove(target.position, 1f);
            }
        }
    }
}

