using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using AmmoStackClone.Controllers;

namespace AmmoStackClone.Managers
{
	public class InputManager : MonoBehaviour
	{
		public static InputManager Instance { get; private set; }
		public bool isInputEnabled { get; private set; } = true;

        private PlayerController _playerController;

        public float horizontalSpeed;
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

        public void Initialize(PlayerController playerController)
        {
            _playerController = playerController;
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
			if (!isInputEnabled || !_isDragging )
			{
				return;
			}

			if (GameManager.Instance.GameState != GameState.Playing) 
            {
                return;
            }

            float lastTouch = Input.mousePosition.x;
            float diff = lastTouch - _firstTouchX;

            float horizontalMovement = diff * horizontalSpeed * Time.deltaTime;

            _playerController.MoveHorizontal(horizontalMovement);
 
            _firstTouchX = lastTouch;
        }

        public void OnScreenUp(PointerEventData eventData)
        {
            _isDragging = false;
        }

    }

}
