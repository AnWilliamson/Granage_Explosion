using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidInstantiate : MonoBehaviour
{
	public GameObject pyramid;
	public GameObject spawnPoint;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			Instantiate (pyramid, spawnPoint.transform.position, spawnPoint.transform.rotation);
		}
	}
}
