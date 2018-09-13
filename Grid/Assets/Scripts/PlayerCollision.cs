using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public ParticleSystem particleSystem;
	public float colliderTimeOut = 1.0f;

	private TrailColliders trailColliders;
	private TrailRenderer trailRenderer;
	private Collider collider;

	private float startTimeOut;

	// Use this for initialization
	private void Awake ()
    {
		trailColliders = GetComponent<TrailColliders>();
		trailRenderer = GetComponent<TrailRenderer>();
		collider = GetComponent<Collider>();
	}

	private void Update()
	{
		if (!collider.enabled)
		{
			if (startTimeOut - Time.realtimeSinceStartup > colliderTimeOut)
			{
				collider.enabled = true;
			}
		}
	}


	private void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;

        if (collider.tag != "Ground")
        {
			particleSystem.Stop();
            particleSystem.Play();
			trailColliders.DisableColliders();
			trailRenderer.Clear();
        }
	}

	private void DisableCollider()
	{
		collider.enabled = false;
		startTimeOut = Time.realtimeSinceStartup;
	}
}
