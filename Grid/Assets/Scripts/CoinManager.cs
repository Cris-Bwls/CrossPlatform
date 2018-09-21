/* 
 Authors-
 Josh
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

	public GameObject m_CoinPrefab;     //stores the coin prefab
	public int m_startingCoinAmount;

	List<GameObject> m_CoinList = new List<GameObject>();		//a list of all the coins in the level

	// Use this for initialization
	void Start()
	{
		//calls AddCoins with the m_startingCoinAmount for start of game
		AddCoins(m_startingCoinAmount);
	}

	//add coins to the coin list, CoinAmount is how many coins you wish to add
	void AddCoins(int CoinAmount)
	{
		for (int i = 0; i < CoinAmount; i++)
		{
			//creates a temp gameobject and sets a random position to it then adds temp to the coinlist
			GameObject temp = Instantiate(m_CoinPrefab, this.gameObject.transform);
			temp.transform.position = new Vector3(Random.value * 100, 0.5f, Random.value * 100);

			m_CoinList.Add(temp);
		}
	}
}
