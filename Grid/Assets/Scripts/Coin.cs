/* 
 Authors-
 Josh
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	CoinManager m_pheonix;

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.Rotate(0, 0, 4);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player1" || other.tag == "Player2")
		{
			other.GetComponent<Score>().AddToScore(100);
			transform.position = new Vector3(Random.value * 100, transform.position.y, Random.value * 100);
		}
	}
}
