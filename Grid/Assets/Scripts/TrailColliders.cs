/* 
 Authors-
	Chris
    Paul
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColliders : MonoBehaviour {

	public float multiplier = 0.85f;	// Multiplier for length of trail

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

		// Determine length of tail
		int colliderNum = (int)(trailRenderer.time * movement.speed * multiplier);

		// Create the list of trail colliders
		for (int i = 0; i < colliderNum; ++i)
		{
			GameObject temp = Instantiate(trailColliderPrefab);
			temp.tag = this.tag;
			colliderList.Add(temp);
		}
	}
	
	// Places the trail collider at position given
	public void PlaceCollider(Vector3 pos)
	{
		// list iterator is higher than list count
		if (listIterator >= colliderList.Count)
			// Set iterator to 0
			listIterator = 0;
		
		// enable the collider and move to the pos
		colliderList[listIterator].SetActive(true);
		colliderList[listIterator].transform.position = pos;
		listIterator++;
	}

	// Disables all the trail Colliders
	public void DisableColliders()
	{
		// for each collider in the list
		foreach (GameObject collider in colliderList)
		{
			// disable the colliders
			collider.SetActive(false);
		}
	}
}
