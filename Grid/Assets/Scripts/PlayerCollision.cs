﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public ParticleSystem particleSystem;
	public float colliderTimeOut = 1.0f;
	public float phase = 0.1f;

	private TrailColliders trailColliders;
	private TrailRenderer trailRenderer;
	private Collider collider;
	private MeshRenderer meshRenderer;

	private Score m_score;

	private float startTimeOut;
	private float startPhase;

	// Use this for initialization
	private void Awake ()
    {
		trailColliders = GetComponent<TrailColliders>();
		trailRenderer = GetComponent<TrailRenderer>();
		collider = GetComponent<Collider>();
		meshRenderer = GetComponent<MeshRenderer>();
		m_score = GetComponent<Score>();
	}

	private void LateUpdate()
	{
		if (!collider.enabled)
		{
			if (startPhase == 0)
				startPhase = Time.realtimeSinceStartup;

			if (Time.realtimeSinceStartup - startPhase > phase)
			{
				startPhase = Time.realtimeSinceStartup;
				meshRenderer.enabled = !meshRenderer.enabled;
			}

			if (Time.realtimeSinceStartup - startTimeOut > colliderTimeOut)
			{
				collider.enabled = true;
				meshRenderer.enabled = true;
				startPhase = 0;
				particleSystem.Stop();
			}
		}
	}


	private void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;

		if (collider.tag != "Ground" || collider.tag != "Coin")
		{
			particleSystem.Stop();
			particleSystem.Play();
			trailColliders.DisableColliders();
			trailRenderer.Clear();

			if(collider == this)
			{
				m_score.ClearScore();
			}
			else
			{
				m_score.ClearScore();
				m_score.AddToScore(100);
			}


			DisableCollider();
        }
	}

	private void DisableCollider()
	{
		collider.enabled = false;
		startTimeOut = Time.realtimeSinceStartup;
	}
}
