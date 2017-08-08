using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "springPainting") {
			gameObject.SetActive (false);
			// NEXT LINE SHOULD ACTIVATE SPRING PAINTING ANIMATION
		}
	}
}
