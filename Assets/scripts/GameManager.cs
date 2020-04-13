using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	public bool isGameover = false;
	public Text scoreText;
	public Text timeText;
	public float time;
	public GameObject gameoverUI;
	private int score = 0;

	void Awake() {
		if(instance == null) {
			instance = this;
		}
	}
	void Update () {
		if(isGameover == false) {
		time += Time.deltaTime;
		timeText.text = "Time: " + string.Format ("{0:0.##}", time);
		}
		if(isGameover && Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}	
	}

	public void AddScore(int newScore) {
		if(!isGameover)  {
			score += newScore;
			scoreText.text = "SCORE: " + score;
		}
	}

	public void OnPlayerDead() {
		isGameover = true;
		gameoverUI.SetActive(true);
	}

}
