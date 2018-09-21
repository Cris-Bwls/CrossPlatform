/*
 Authors

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	public GameObject m_CoinPrefab;

	GameObject[] m_CoinList = new GameObject[10];

	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			m_CoinList[i] = Instantiate(m_CoinPrefab, this.gameObject.transform);
			m_CoinList[i].transform.position = new Vector3(Random.value * 100, 0.5f, Random.value * 100);
		}
	}
}
