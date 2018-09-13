using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	int m_nScore;
	public Text m_ScoreText;

	public Score otherPlayer;

	// Use this for initialization
	void Start () 
	{
		m_nScore = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_ScoreText.text = m_nScore.ToString();
	}

	public void AddToScore(int score)
	{
		m_nScore = score;
	}

	public void ClearScore()
	{
		m_nScore = 0;
	}
}
