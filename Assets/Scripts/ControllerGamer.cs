using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControllerGamer : MonoBehaviour {
	[SerializeField]
	private int totalBlocksInScene;
	private int totalBlocksEnabled = 0;

	[SerializeField]
	private GameObject gameOverObject;

	[SerializeField]
	private Text totalBlocksText;

	[SerializeField]
	private Text timeText;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private int scoreWinnerByBlock;

	[SerializeField]
	private int totalTimeMax;
	private float currentTime;

	[SerializeField]
	private string nextLevelSceneName;

	private int highScore = 0;
	private int currentScore = 0;

	private void Start() {
		currentTime = totalTimeMax;
		highScore = PlayerPrefs.GetInt("Score:Best", highScore);
		currentScore = PlayerPrefs.GetInt("Score:Current", currentScore);
	}

	private void Update() {
		currentTime -= Time.deltaTime;
		if (currentTime <= 0) {
			currentTime = 0;
			ShowGameOver();
		}

		int minutes = Mathf.FloorToInt(currentTime / 60);
		int seconds = Mathf.FloorToInt(currentTime % 60);

		timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

		UpdateScreenBlocks();
		UpdateScoreBoard();
	}

	public void UpdateScoreBoard() {
		scoreText.text = "Score: " + currentScore;

		PlayerPrefs.SetInt("Score:Current", currentScore);
		if (currentScore > highScore) {
			highScore = currentScore;
			PlayerPrefs.SetInt("Score:Best", highScore);
		}

		PlayerPrefs.Save();
	}

	public void UpdateScreenBlocks() {
		totalBlocksText.text = "Blocks: " + totalBlocksInScene + "/" + totalBlocksEnabled;

		if (totalBlocksEnabled >= totalBlocksInScene) {
			StartCoroutine("CheckEndLevel");
		}
	}

	public void DisincrementBlocksEnabled() {
		totalBlocksEnabled--;
		currentScore -= scoreWinnerByBlock;
		UpdateScreenBlocks();
		UpdateScoreBoard();
	}

	public void IncrementBlocksEnabled() {
		totalBlocksEnabled++;
		currentScore += scoreWinnerByBlock;
		UpdateScreenBlocks();
		UpdateScoreBoard();
	}

	public void ShowGameOver() {
		currentScore = 0;
		UpdateScoreBoard();
		gameOverObject.SetActive(true);
	}

	public void RestartGame() {
		SceneManager.LoadScene("MainMenu");
	}

	public void NextLevel() {
		currentScore += (int) currentTime;
		UpdateScoreBoard();
		SceneManager.LoadScene(nextLevelSceneName);
	}

	IEnumerator CheckEndLevel() {
		yield return new WaitForSeconds(2);
		if (totalBlocksEnabled >= totalBlocksInScene) {
			NextLevel();
		}
	}
}
