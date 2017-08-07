using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCheckPerspective : MonoBehaviour {

	public GameObject viveModel;

	PickupParent pickupParent;

	private bool correctPos;
	// Use this for initialization
	void Start () {
        /*
        portalAnimator.StopPlayback();
        portalAnimator.speed = 0;
        */
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
				viveModel.SetActive (true);
			}
			else if (hit.collider.tag == "focus") {
				Debug.Log ("Gaze is correct, but position is wrong");
			}
		}
	}
	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "posBox")
        {
            Debug.Log("you have hit the posbox");
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
