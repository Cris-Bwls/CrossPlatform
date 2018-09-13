using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

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
			Destroy(this.gameObject);
		}
	}
}
