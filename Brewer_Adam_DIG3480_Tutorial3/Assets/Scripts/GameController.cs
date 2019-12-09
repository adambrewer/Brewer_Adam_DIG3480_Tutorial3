﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

public AudioClip bgMusic;
public AudioClip winClip;
public AudioClip loseClip;

	public Text ScoreText;
	private int score;
	private bool timerOff;
	
	public Text restartText;
	public Text gameOverText;
	public Text winText;

	private bool gameOverMan;
	private bool restart;
	private bool youWin;


    void Start()
    {
	gameOverMan = false;
	restart = false;
	youWin = false;
	timerOff = false;
	winText.text = "";
	restartText.text = "";
	gameOverText.text ="";
	score = 0;
AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

void UpdateScore()
{
ScoreText.text = "Points: " + score;
}
	StartCoroutine (SpawnWaves ());        
    }

void Update()
{
if (Input.GetKey("escape"))
     Application.Quit();
if (restart)
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			SceneManager.LoadScene("SampleScene");
		}
	}
	if (timerOff == false)
	{	
		if (Input.GetKeyDown(KeyCode.U))
		{
		timerOff = true;
		}
	}
}

    IEnumerator SpawnWaves()
    {
	yield return new WaitForSeconds (startWait);

	while (true)
{
	for(int i = 0; i < hazardCount; i++)
	{
	GameObject hazard = hazards[Random.Range (0, hazards.Length)];
        Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
	Quaternion spawnRotation = Quaternion.identity;
	Instantiate (hazard, spawnPosition, spawnRotation);
	yield return new WaitForSeconds (spawnWait);
	}
	yield return new WaitForSeconds(waveWait);

	if (gameOverMan)
	{
		restartText.text = "Press 'T' to Restart";
		restart = true;
		break;
	}
	if (youWin)
	{
		restartText.text = "Press 'T' to Restart";
		restart = true;
		break;
	}

}
    }
void UpdateScore()
{
ScoreText.text = "Points: " + score;
}

public void AddScore(int newScoreValue)
{
score += newScoreValue;
UpdateScore();
	if (timerOff == false)
{
	if (score >= 100)
	{
	youWin = true;
	winText.text = "You Win!  Game created by Adam Brewer.";
	GetComponent<AudioSource>().clip = winClip;
       	GetComponent<AudioSource>().Play();
}
	}
}

public void gameOver()
	{
		gameOverText.text = "Game Over!";
		gameOverMan = true;
		GetComponent<AudioSource>().clip = loseClip;
       		GetComponent<AudioSource>().Play();
	}


}


