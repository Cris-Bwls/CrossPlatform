using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    // Use this for initialization
    public int playerLives = 5;
    public bool dead = false;

	void Start ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider)
        {
            if (playerLives < 1)
            {
                dead = true;

            }

            playerLives -= 1;
            Debug.Log("Player Lives Left " + playerLives);
        }
    }

     //Update is called once per frame
    void Update ()
    {
        if(dead == true)
        {
            //transform.position = new Vector3(50, 0, 50);

        }
	}
}
