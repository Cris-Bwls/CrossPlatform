/* 
 Authors-
 Paul
 Joshua
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    // Use this for initialization
    public int m_playerLives = 5;
    public bool dead = false;

    private int currentLives;
    private Vector3 pos;

	public GameObject[] lifeVisualiser = new GameObject[5];
    public GameObject otherPlayer;
    private Score playerScore;
    private PlayerLives otherPlayerLives;

    void Awake ()
    {
        currentLives = m_playerLives;
        playerScore = GetComponent<Score>();
        otherPlayerLives = otherPlayer.GetComponent<PlayerLives>();
        //pos = this.transform.position;
    }

     //Update is called once per frame
    void  FixedUpdate ()
    {
        Debug.Log(gameObject.tag + " has " + m_playerLives + " lives left");

        if (currentLives <= 0)
        {
            ResetGame();
            otherPlayerLives.ResetGame();
        }
		else if (m_playerLives < currentLives)
		{
            currentLives = m_playerLives;
			lifeVisualiser[currentLives].SetActive(false);
		}
	}

    public void ResetGame()
    {
        playerScore.ClearScore();
        currentLives = 5;
        m_playerLives = 5;
        foreach (GameObject temp in lifeVisualiser)
        {
            temp.SetActive(true);
        }
    }
}
