using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AmmoStackClone.Managers;
using TMPro;
using DG.Tweening;

namespace AmmoStackClone.Canvases
{
	public class GameCanvas : MonoBehaviour
	{
		[SerializeField] private Button playButton;
		[SerializeField] private TextMeshProUGUI levelText;
		[SerializeField] private Image levelImage;
		[SerializeField] private Image swipeToStartImage;
		public void Initialize()
		{
			playButton.onClick.AddListener(OnPlayButtonClick);

		}

		private void OnEnable()
		{
			GameManager.OnGameStarted += OnGameStart;
			GameManager.OnGameReset += OnGameReset;
			GameManager.OnGameEnd += OnGameEnd;
		}

		private void OnDisable()
		{
			GameManager.OnGameStarted -= OnGameStart;
			GameManager.OnGameReset -= OnGameReset;
			GameManager.OnGameEnd -= OnGameEnd;

		}

		private void OnGameStart()
		{
			UpdateLevelText();
			levelImage.gameObject.SetActive(true);
			swipeToStartImage.gameObject.SetActive(true);
		}

		private void OnGameReset()
		{
			playButton.gameObject.SetActive(true);
		}

		private void OnGameEnd(bool isSuccessful)
		{
			DOVirtual.DelayedCall(1f, () =>
			{
				levelImage.gameObject.SetActive(false);

			});

		}

		private void OnPlayButtonClick()
		{
			Debug.Log("OnPlayButtonClick calisti");
			GameManager.Instance.ChangeState(GameState.Playing);
			playButton.gameObject.SetActive(false);
			swipeToStartImage.gameObject.SetActive(false);
		}

		private void UpdateLevelText()
		{
			int currentLevel = PlayerPrefsManager.CurrentLevel;
			levelText.text = "LEVEL " + currentLevel.ToString();
		}

	}

}
