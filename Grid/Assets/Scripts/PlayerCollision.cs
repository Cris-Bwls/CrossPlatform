/* 
 Authors-
	Chris
*/

using System.Collections;
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
    private PlayerLives playerLives;

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
        playerLives = GetComponent<PlayerLives>();
	}

	// Updates any ongoing effects
	private void Update()
	{
		// if collider is NOT enabled
		if (!collider.enabled)
		{
			// IF start phase has not been set
			if (startPhase == 0)
				// Set start phase
				startPhase = Time.realtimeSinceStartup;

			// IF phase time has passed
			if (Time.realtimeSinceStartup - startPhase > phase)
			{
				// Set start phase and invert mesh renderer
				startPhase = Time.realtimeSinceStartup;
				meshRenderer.enabled = !meshRenderer.enabled;
			}

			// IF collider time out has passed
			if (Time.realtimeSinceStartup - startTimeOut > colliderTimeOut)
			{
				// Re-enable collider and mesh renderer
				collider.enabled = true;
				meshRenderer.enabled = true;

				// Reset Startphase to 0
				startPhase = 0;
				
				// Stop particle system
				particleSystem.Stop();
			}
		}
	}

	// When player collides it decrements lives and starts effects
	private void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;

		// IF NOT colliding with ground or coin
		if (collider.tag != "Ground" || collider.tag != "Coin")
		{
			// Reset and start Particle system 
			particleSystem.Stop();
			particleSystem.Play();

			// Clear and disable trail collider
			trailColliders.DisableColliders();
			trailRenderer.Clear();

			// Decrement Player lives
            playerLives.m_playerLives--;

			if(collider.tag == tag)
			{
				m_score.ClearScore();
			}
			else
			{
				m_score.otherPlayer.AddToScore(m_score.GetScore());
				m_score.ClearScore();
			}

			// call DisableCollider
			DisableCollider();
        }
	}

	// Disables players collider
	private void DisableCollider()
	{
		// Disable collider
		collider.enabled = false;

		// Set collider time out
		startTimeOut = Time.realtimeSinceStartup;
	}
}
