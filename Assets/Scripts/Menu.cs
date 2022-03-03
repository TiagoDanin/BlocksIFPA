using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour {
	[SerializeField]
	private string startLevelSceneName;

	[SerializeField]
	private TextMeshProUGUI highScoreText;

	private int highScore = 0;

	private void Start() {
		PlayerPrefs.SetInt("Score:Current", 0);
		PlayerPrefs.Save();

		highScore = PlayerPrefs.GetInt("Score:Best", highScore);
		highScoreText.text = "Best Score: " + highScore;
	}

	public void StartGame() {
		SceneManager.LoadScene(startLevelSceneName);
	}
}
