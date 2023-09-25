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
		void Start()
		{

		}

		void Update()
		{

		}

		private void OnPlayButtonClick()
		{
			Debug.Log("OnPlayButtonClick calisti");
			GameManager.Instance.ChangeState(GameState.Playing);
			playButton.gameObject.SetActive(false);
		}

	}

}
