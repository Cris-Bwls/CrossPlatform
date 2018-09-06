using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColliders : MonoBehaviour {
	
	private TrailRenderer trailRenderer;
	private Movement movement;

	private List<BoxCollider> colliderList = new List<BoxCollider>(); 

	// Use this for initialization
	void Start ()
	{
		trailRenderer = GetComponent<TrailRenderer>();
		movement = GetComponent<Movement>();

		int colliderNum = 0;
		for (int i = 0; i < colliderNum; ++i)
		{
			var temp = new BoxCollider();
			temp.enabled = false;
			temp.isTrigger = true;
			colliderList.Add(new BoxCollider());
		}
	}
	
	// Update is called once per frame
	public void UpdateColliders ()
	{
		
	}
}
