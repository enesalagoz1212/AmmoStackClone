using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using AmmoStackClone.Managers;

namespace AmmoStackClone.Canvases
{
	public class EndCanvas : MonoBehaviour
	{
		public GameObject endPanel;
		public TextMeshProUGUI endLevelText;

		private void OnEnable()
		{
			GameManager.OnGameStarted += OnGameStart;
			GameManager.OnGameEnd += OnGameEnd;
		}

		private void OnDisable()
		{
			GameManager.OnGameStarted -= OnGameStart;
			GameManager.OnGameEnd -= OnGameEnd;
		}

		private void OnGameStart()
		{
			endPanel.gameObject.SetActive(false);

		}

		private void OnGameEnd(bool isSuccessful)
		{
			if (isSuccessful)
			{
				DOVirtual.DelayedCall(1f, () =>
				{
					endPanel.gameObject.SetActive(true);
					UpdateEndLevelText();
				});				
			}
		}

		private void UpdateEndLevelText()
		{
			var finishedLevel = PlayerPrefsManager.CurrentLevel - 1;
			endLevelText.text = "LEVEL " + finishedLevel.ToString();
		}

	}
}

