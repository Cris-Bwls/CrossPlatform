/* 
 Authors-
 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColliders : MonoBehaviour {

	public float multiplier = 0.85f;

	public GameObject trailColliderPrefab;

	private TrailRenderer trailRenderer;
	private Movement movement;

	private List<GameObject> colliderList = new List<GameObject>();
	private int listIterator = 0; 

	// Use this for initialization
	void Start ()
	{
		trailRenderer = GetComponent<TrailRenderer>();
		movement = GetComponent<Movement>();

		int colliderNum = (int)(trailRenderer.time * movement.speed * multiplier);
		for (int i = 0; i < colliderNum; ++i)
		{
			GameObject temp = Instantiate(trailColliderPrefab);
			temp.tag = this.tag;
			colliderList.Add(temp);
		}
	}
	
	public void PlaceCollider(Vector3 pos)
	{
		if (listIterator >= colliderList.Count)
			listIterator = 0;
		
		colliderList[listIterator].SetActive(true);
		colliderList[listIterator].transform.position = pos;
		listIterator++;
	}

	public void DisableColliders()
	{
		foreach (GameObject collider in colliderList)
		{
			collider.SetActive(false);
		}
	}
}
