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
		private LevelManager _levelManager;

		[SerializeField] private Button playButton;
		[SerializeField] private TextMeshProUGUI levelText;
		[SerializeField] private Image levelImage;
		[SerializeField] private Image swipeToStartImage;
		[SerializeField] private Image fullImage;
		[SerializeField] private Image sliderImage;
		public void Initialize(LevelManager levelManager)
		{
			_levelManager = levelManager;
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
			fullImage.fillAmount = 0f;
			UpdateLevelText();
			levelImage.gameObject.SetActive(true);
			swipeToStartImage.gameObject.SetActive(true);
			sliderImage.gameObject.SetActive(true);
		}

		private void OnGameReset()
		{
			playButton.gameObject.SetActive(true);
		}

		private void OnGameEnd(bool isSuccessful)
		{
			sliderImage.gameObject.SetActive(false);
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

		private void Update()
		{
			if (GameManager.Instance.GameState==GameState.Playing)
			{
				float playerPragress = _levelManager.ReturnPlayerProgress();
				fullImage.fillAmount = playerPragress;
			}
		}

	}

}
