using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	CoinManager m_pheonix;

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.Rotate(0, 0, 4);
		//transform.rotation = Quaternion.Euler(90, 0, transform.rotation.eulerAngles.z + Time.fixedTime);
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
