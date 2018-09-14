using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    // Use this for initialization
    public int playerLives = 5;
    public bool dead = false;

    private int currentLives;
    private Vector3 pos;

    void Awake ()
    {
        currentLives = playerLives;
        //pos = this.transform.position;
	}

     //Update is called once per frame
    void Update ()
    {
        if (currentLives > playerLives)
        {
            currentLives = playerLives;
            Debug.Log(gameObject.tag + " has " + playerLives + " lives left");

            if (playerLives <= 0)
            {
                dead = true;
            }

            if (dead)
            {
                
            }
        }

	}
}
