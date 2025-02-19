﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
	public float delay = 3f;
	public float radius = 5f;
	public float explosionForce = 700f;

	public GameObject explosionEffect;

	float countdown;
	bool hasExploded = false;

	// Use this for initialization
	void Start ()
	{
		countdown = delay;
	}
	
	// Update is called once per frame
	void Update ()
	{
		countdown -= Time.deltaTime;
		if (countdown <= 0f && !hasExploded) {
			Explode ();
			hasExploded = true;
		}
	}

	void Explode ()
	{
		GameObject effect = Instantiate (explosionEffect, transform.position, transform.rotation);
		Destroy (effect, 2f);

		Collider[] collidersToDestroy = Physics.OverlapSphere (transform.position, radius);

		foreach (Collider nearbyObject in collidersToDestroy) {
			Destructible dest = nearbyObject.GetComponent<Destructible> ();

			if (dest != null) {
				dest.Destroy ();
			}
		}

		Collider[] collidersToMove = Physics.OverlapSphere (transform.position, radius);

		foreach (Collider nearbyObject in collidersToMove) {
			Rigidbody rb = nearbyObject.GetComponent<Rigidbody> ();
			if (rb != null) {
				Debug.Log ("BOOM!");
				rb.AddExplosionForce (explosionForce, transform.position, radius); 
			}
		}

		Destroy (gameObject);
	}
}
