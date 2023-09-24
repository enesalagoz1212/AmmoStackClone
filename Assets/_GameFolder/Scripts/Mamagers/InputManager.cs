using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AmmoStackClone.Managers
{
	public class InputManager : MonoBehaviour
	{
		public static InputManager Instance { get; private set; }
		public bool isInputEnabled { get; private set; } = true;


        private float _firstTouchX;
        private bool _isDragging;


        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public void Initialize()
        {
            _isDragging = false;
        }

        public void OnScreenTouch(PointerEventData eventData)
        {
            if (!isInputEnabled)
            {
                return;
            }

            _firstTouchX = Input.mousePosition.x;
            _isDragging = true;
        }

        public void OnScreenDrag(PointerEventData eventData)
        {
            if (!isInputEnabled || !_isDragging)
            {
                return;
            }
            float lastTouch = Input.mousePosition.x;
            float diff = lastTouch - _firstTouchX;

            MoveObject(diff);

            _firstTouchX = lastTouch;
        }

        public void OnScreenUp(PointerEventData eventData)
        {
            _isDragging = false;
        }

        private void MoveObject(float amount)
        {
            Vector3 newPosition = transform.position + new Vector3(amount, 0f, 0f);

          
            float minX = -3.8f; 
            float maxX = 3.8f;  
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            transform.position = newPosition;
        }

    }

}
