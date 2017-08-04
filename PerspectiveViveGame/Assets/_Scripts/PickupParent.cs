using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public bool touchpadDown = false;

	void Awake () {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void FixedUpdate () {
		device = SteamVR_Controller.Input ((int)trackedObj.index);

		if(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
		{
			Debug.Log ("Trigger held");
		}
	}
	void Update() {
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad)) {
			touchpadDown = true;
		}

		if (device.GetPressUp (SteamVR_Controller.ButtonMask.Touchpad)) {
			touchpadDown = false;
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "key") {
			if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
				Debug.Log ("Object grabbed");
				other.attachedRigidbody.isKinematic = true;
				other.gameObject.transform.SetParent (gameObject.transform);
			}
			if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
					
				Debug.Log ("Object dropped");
				other.attachedRigidbody.isKinematic = false;
				other.gameObject.transform.SetParent (null);
			}
		}
	}
}
