using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;


	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	// Use this for initialization
	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);

		if(device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
		{
			SceneManager.LoadScene ("FirstLevel");
		}
	}
}
