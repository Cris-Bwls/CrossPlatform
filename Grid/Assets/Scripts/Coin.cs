/* 
 Authors-
 Josh
 Paul
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate()
	{
		//rotates the coin over time
		transform.Rotate(0, 0, 4);
	}

	private void OnTriggerEnter(Collider other)
	{
		//if the coin collides with a player
		if (other.tag == "Player1" || other.tag == "Player2")
		{
			//add to the players score
			other.GetComponent<Score>().AddToScore(100);
			//give the coin a new position on the board
			transform.position = new Vector3(Random.value * 100, transform.position.y, Random.value * 100);
		}
	}
}
