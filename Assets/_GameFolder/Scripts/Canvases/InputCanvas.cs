using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Canvases
{
	public class InputCanvas : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
	{
		private InputManager _inputManager;
		private bool _inputEnabled = true;

		public void Initialize(InputManager inputManager)
		{
			_inputManager = inputManager;
		//	Debug.Log("1");
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_inputEnabled)
			{
				Debug.Log("2");
				_inputManager.OnScreenTouch(eventData);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (_inputEnabled)
			{
				Debug.Log("3");
				_inputManager.OnScreenDrag(eventData);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			Debug.Log("4");
			_inputManager.OnScreenUp(eventData);
		}

		public void DisableInput()
		{
			_inputEnabled = false;
		}

		public void EnableInput()
		{
			_inputEnabled = true;
		}
	}
}

