using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	CoinManager m_pheonix;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player1" || other.tag == "Player2")
		{
			other.GetComponent<Score>().AddToScore(100);
			transform.position = new Vector3(Random.value * 100, 0, Random.value * 100);
		}
	}
}
