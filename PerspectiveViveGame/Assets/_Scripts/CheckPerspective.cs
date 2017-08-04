using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPerspective : MonoBehaviour {

	public GameObject realKey;
	public GameObject puzzleKey;

    public static bool keyInHole;
    private bool portalPlayed = false;
	PickupParent pickupParent;

    [SerializeField]
    private GameObject portal;

    private Animator portalAnimator;

	private bool correctPos;
	// Use this for initialization
	void Start () {
        portalAnimator = portal.GetComponent<Animator>();
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
			if (hit.collider.tag == "focus" && correctPos && GameObject.Find("[CameraRig]").GetComponentInChildren<PickupParent> ().touchpadDown) {
				Debug.Log ("Key found!");
				realKey.SetActive (true);
				puzzleKey.SetActive (false);
			}
			else if (hit.collider.tag == "focus") {
				Debug.Log ("Gaze is correct, but position is wrong");
			}
		}
        if (keyInHole) {
            if (!portalPlayed) {
                portalAnimator.SetBool("TouchedPortal", true);
                portalPlayed = true;
            }
        }
	}
	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "portal" && portalPlayed) {
            Debug.Log("you have hit the portal");
            //portalAnimator.Play("Take 001");
            //portalAnimator.SetBool("TouchedPortal", true);
            SceneManager.LoadScene("SecondLevel");
            Debug.Log("this should not print");
        }
        if (other.tag == "posBox")
        {
            Debug.Log("you have hit the posbioox0");
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
