using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPerspective2 : MonoBehaviour {

	public GameObject solvedPerson;
	public GameObject puzzlePerson;
	public GameObject solvedWord;
	public GameObject puzzleWord;
	public GameObject wordCollider;

    public static bool portalShouldOpen;
    private bool portalOnePlayed = false;
    private bool portalTwoPlayed = false;
	PickupParent pickupParent;

    [SerializeField]
    private GameObject portal2;

    private Animator personAnimator;

	private bool correctPosPerson;
	private bool correctPosWord;
	// Use this for initialization
	void Start () {
        personAnimator = solvedPerson.GetComponent<Animator>();
        /*
        portalAnimator.StopPlayback();
        portalAnimator.speed = 0;
        */
        correctPosPerson = false;
		correctPosWord = false;
	}
	
	// Update is called once per frame
	void Update () {
		var vrcam = SteamVR_Render.Top();
		Ray ray = new Ray (vrcam.head.position, vrcam.head.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000)) {
			if (hit.collider.tag == "focus" && correctPosPerson && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				solvedPerson.SetActive (true);
				puzzlePerson.SetActive (false);
				personAnimator.SetBool ("Played", true);
			}
			else if (hit.collider.tag == "focusPerson") {
				Debug.Log ("Gaze is correct, but position is wrong");
			}
			if (hit.collider.tag == "focusWord" && correctPosWord && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().touchpadDown || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().touchpadDown)) {
				solvedWord.SetActive (true);
				puzzleWord.SetActive (false);
				wordCollider.SetActive (true);
			}
		}
        if (portalShouldOpen) {
            if (!portalOnePlayed) {
                //personAnimator.SetBool("TouchedPortal", true);
                portalOnePlayed = true;
            }
        }
	}
	void OnTriggerEnter(Collider other)
	{
        if (other.tag == "posBox")
        {
            Debug.Log("you have hit the posbioox0");
            correctPosPerson = true;
        }
		if (other.tag == "posBoxWord")
		{
			Debug.Log("you have hit the posbioox0");
			correctPosWord = true;
		}
        if (other.tag == "portal2") {
            Debug.Log("you have hit the portal in level 2");
            SceneManager.LoadScene("ThirdLevel");
            Debug.Log("this should also not print");
        }
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "posBox") {
			correctPosPerson = false;
		}
		if (other.tag == "posBoxWord") {
			correctPosWord = false;
		}
	}

}
