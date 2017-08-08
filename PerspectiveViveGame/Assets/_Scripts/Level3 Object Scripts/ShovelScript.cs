using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour {

	public bool summerBool;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "summerPainting") {
			gameObject.SetActive (false);
			if (summerBool) {
				// NEXT LINE SHOULD ACTIVATE WINTER PAINTING ANIMATION
			} else {
				summerBool = true;
			}
		}
	}
}
