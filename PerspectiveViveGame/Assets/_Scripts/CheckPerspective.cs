using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPerspective : MonoBehaviour {

	public GameObject realKey;
	public GameObject puzzleKey;

    public static bool keyInHole;
    private bool portalOnePlayed = false;
    private bool portalTwoPlayed = false;
	PickupParent pickupParent;

    private AudioSource mainMusic;

    [SerializeField]
    private GameObject portal;

    private Animator portalAnimator;

	private bool correctPos;
	// Use this for initialization
	void Start () {
        portalAnimator = portal.GetComponent<Animator>();
        mainMusic = GetComponent<AudioSource>();
        mainMusic.Play();
        correctPos = false;
	}
	
	// Update is called once per frame
	void Update () {
		var vrcam = SteamVR_Render.Top();
		Ray ray = new Ray (vrcam.head.position, vrcam.head.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000)) {
			if (hit.collider.tag == "focus" && correctPos && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				Debug.Log ("Key found!");
				realKey.SetActive (true);
				puzzleKey.SetActive (false);
			}
			else if (hit.collider.tag == "focus") {
				Debug.Log ("Gaze is correct, but position is wrong");
			}
		}
        if (keyInHole) {
            if (!portalOnePlayed) {
				portal.SetActive (true);
				StartCoroutine ("PortalOpen");
                portalOnePlayed = true;
            }
        }
	}
	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "portal" && portalOnePlayed) {
            Debug.Log("you have hit the portal in level 1");
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
        if (other.tag == "portal2" && portalTwoPlayed) {
            Debug.Log("you have hit the portal in level 2");
            SceneManager.LoadScene("ThirdLevel");
            Debug.Log("this should also not print");
        }
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "posBox") {
			correctPos = false;
		}
	}

	IEnumerator PortalOpen() {
		for (float f = 0f; f <= portal.transform.localScale.z; f += (portal.transform.localScale.z/40)) {
			portal.transform.localScale.Set (portal.transform.localScale.x, portal.transform.localScale.y, f);
			yield return new WaitForSeconds(.1f);
		}
	}

}
