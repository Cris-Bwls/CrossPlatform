using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public ParticleSystem particleSystem;

	private TrailColliders trailColliders;
	private TrailRenderer trailRenderer;

	// Use this for initialization
	void Awake ()
    {
		trailColliders = GetComponent<TrailColliders>();
		trailRenderer = GetComponent<TrailRenderer>();
	}
	

	void OnCollisionEnter(Collision collision)
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
}
