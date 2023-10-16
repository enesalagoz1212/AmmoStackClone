using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AmmoStackClone.Managers;
using TMPro;

namespace AmmoStackClone.Canvases
{
	public class GameCanvas : MonoBehaviour
	{
		[SerializeField] private Button playButton;
		[SerializeField] private TextMeshProUGUI levelText;

		public void Initialize()
		{
			playButton.onClick.AddListener(OnPlayButtonClick);

		}

		private void OnEnable()
		{
			GameManager.OnGameStarted += OnGameStart;
			GameManager.OnGameReset += OnGameReset;

		}

		private void OnDisable()
		{
			GameManager.OnGameStarted -= OnGameStart;
			GameManager.OnGameReset -= OnGameReset;

		}

		private void OnGameStart()
		{
			UpdateLevelText();
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

		private void UpdateLevelText()
		{
			Debug.Log(PlayerPrefsManager.CurrentLevel);
			int currentLevel = PlayerPrefsManager.CurrentLevel;
			levelText.text = "LEVEL " + currentLevel.ToString();
		}

	}

}
