using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Controllers
{
    public class CameraController : MonoBehaviour
    {
        private LevelManager _levelManager;
        
        public GameObject bullet;
        public Vector3 offset;
        private float _cameraY;

        public void Initialize(LevelManager levelManager)
		{
            _levelManager = levelManager;
		}
        void Start()
        {
            _cameraY = transform.position.y;
            offset = transform.position - bullet.transform.position;
           
        }

		private void LateUpdate()
		{
			if (_levelManager.CurrentBulletTransform!=null)
			{
                Debug.Log("CurrentBulletTransform null degil");
                Vector3 position = _levelManager.CurrentBulletTransform.position + offset;
                position.y = _cameraY;
                transform.position = position;
            }
            
		}
    }
}

