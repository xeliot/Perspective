using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "fallPainting") {
			gameObject.SetActive (false);
			// NEXT LINE SHOULD ACTIVATE FALL PAINTING ANIMATION
		}
	}
}
