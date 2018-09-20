using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    // Use this for initialization
    public int m_playerLives = 5;
    public bool dead = false;

    private int currentLives;
    private Vector3 pos;

	public GameObject[] LifeVisualiser = new GameObject[5];

    void Awake ()
    {
        currentLives = m_playerLives;
        //pos = this.transform.position;
	}

     //Update is called once per frame
    void Update ()
    {
        if (currentLives > m_playerLives)
        {
            currentLives = m_playerLives;
            Debug.Log(gameObject.tag + " has " + m_playerLives + " lives left");

            if (m_playerLives <= 0)
            {
                dead = true;
            }

			LifeVisualiser[currentLives].SetActive(false);

            if (dead)
            {
                
            }
        }

	}
}
