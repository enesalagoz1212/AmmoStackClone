using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace AmmoStackClone.Controllers
{
    public class WeaponController : MonoBehaviour
    {
		private void OnEnable()
		{
			
		}
		private void OnDisable()
		{
			
		}
		void Start()
        {
            transform.DORotate(new Vector3(0, -180, 0), 2.0f).SetEase(Ease.InOutSine);
        }
        void Update()
        {

        }
    }
}

