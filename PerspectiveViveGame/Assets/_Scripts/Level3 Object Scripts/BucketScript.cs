using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScripts : MonoBehaviour {

	ShovelScript shovelScript;

	void Update () {
		//shovelScript = GameObject.Find("Shovel").GetComponent<ShovelScript>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "summerPainting") {
			if (shovelScript.summerBool) {
				// NEXT LINE SHOULD ACTIVATE SUMMER PAINTING ANIMATION
			} else {
				shovelScript.summerBool = true;
			}
		}
	}
}
