/* 
 Authors-
	Josh

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	int m_nScore;		//the score
	public Text m_ScoreText;		//a reference to the UI to update the score visual

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

	//adds score parameter to m_nScore
	public void AddToScore(int score)
	{
		m_nScore += score;
	}

	//returns the score
	public int GetScore()
	{
		return m_nScore;
	}

	//clears the score
	public void ClearScore()
	{
		m_nScore = 0;
	}
}
