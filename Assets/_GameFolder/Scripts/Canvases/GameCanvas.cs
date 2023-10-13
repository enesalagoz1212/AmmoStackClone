using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Canvases
{
	public class GameCanvas : MonoBehaviour
	{
		[SerializeField] private Button playButton;

		public void Initialize()
		{
			playButton.onClick.AddListener(OnPlayButtonClick);

		}

		private void OnEnable()
		{
			GameManager.OnGameReset += OnGameReset;

		}

		private void OnDisable()
		{
			GameManager.OnGameReset -= OnGameReset;
			
		}
		
		private void OnGameReset()
		{
			playButton.gameObject.SetActive(true);
		}

		private void OnPlayButtonClick()
		{
			Debug.Log("OnPlayButtonClick calisti");
			GameManager.Instance.ChangeState(GameState.Playing);
			playButton.gameObject.SetActive(false);
		}

	}

}
