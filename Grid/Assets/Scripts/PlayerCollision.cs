using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public ParticleSystem particleSystem;

	// Use this for initialization
	void Awake ()
    {
	}
	

	void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;

        if (collider.tag != "Ground")
        {
            particleSystem.Play();
        }
	}
}
