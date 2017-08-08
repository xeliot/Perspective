using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPerspective3 : MonoBehaviour {

	public GameObject realUmbrella;
	public GameObject puzzleUmbrella;
	public GameObject realBucket;
	public GameObject puzzleBucket;
	public GameObject realRake;
	public GameObject puzzleRake;
	public GameObject realSled;
	public GameObject puzzleSled;
	public GameObject realShovel;
	public GameObject puzzleShovel;


    private bool portalThreePlayed = false;
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
			if (hit.collider.tag == "focusUmbrella" && correctPos && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				Debug.Log ("Umbrella found!");
				realUmbrella.SetActive (true);
				puzzleUmbrella.SetActive (false);
			}
			if (hit.collider.tag == "focusBucket" && correctPos && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				Debug.Log ("Bucket found!");
				realBucket.SetActive (true);
				puzzleBucket.SetActive (false);
			}
			if (hit.collider.tag == "focusRake" && correctPos && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				Debug.Log ("Rake found!");
				realRake.SetActive (true);
				puzzleRake.SetActive (false);
			}
			if (hit.collider.tag == "focusSled" && correctPos && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				Debug.Log ("Sled found!");
				realSled.SetActive (true);
				puzzleSled.SetActive (false);
			}
			if (hit.collider.tag == "focusShovel" && correctPos && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				Debug.Log ("Shovel found!");
				realShovel.SetActive (true);
				puzzleShovel.SetActive (false);
			}
		}
		/*if (summerSolved && winterSolved && springSolved && fallSolved) {
            if (!portalThreePlayed) {
				portal.SetActive (true);
				StartCoroutine ("PortalOpen");
                portalThreePlayed = true;
            }
        }*/
	}
	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "posBox")
        {
            Debug.Log("you have hit the posbioox0");
            correctPos = true;
        }
        if (other.tag == "portal3" && portalThreePlayed) {
            Debug.Log("you have hit the portal in level 3");
            //SceneManager.LoadScene("EndCredits");
            //Debug.Log("this should also not print");
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
