using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPerspective : MonoBehaviour {

	private bool correctPos;
	// Use this for initialization
	void Start () {
		correctPos = false;
	}
	
	// Update is called once per frame
	void Update () {
		var vrcam = SteamVR_Render.Top();
		Ray ray = new Ray (vrcam.head.position, vrcam.head.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000)) {
			if (hit.collider.tag == "focus" && correctPos) {
				Debug.Log ("Key found!");
			}
			else if (hit.collider.tag == "focus") {
				Debug.Log ("Gaze is correct, but position is wrong");
			}
		}

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "posBox") {
			correctPos = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "posBox") {
			correctPos = false;
		}
	}

}
