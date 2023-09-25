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
            if (!isInputEnabled || !_isDragging || LevelManager.Instance.CurrentBulletTransform == null)
            {
                return;
            }

            if (GameManager.Instance.GameState != GameState.Playing) // Oyun durumu "Playing" deðilse hareket etmeyi engelle
            {
                return;
            }

            float lastTouch = Input.mousePosition.x;
            float diff = lastTouch - _firstTouchX;

            float horizontalMovement = diff * horizontalSpeed * Time.deltaTime;

            Vector3 newPosition = LevelManager.Instance.CurrentBulletTransform.position + new Vector3(horizontalMovement, 0f, 0f);

            float minX = -3.8f;
            float maxX = 3.8f;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            LevelManager.Instance.CurrentBulletTransform.position = newPosition;

            _firstTouchX = lastTouch;
        }

        public void OnScreenUp(PointerEventData eventData)
        {
            _isDragging = false;
        }

    }

}
