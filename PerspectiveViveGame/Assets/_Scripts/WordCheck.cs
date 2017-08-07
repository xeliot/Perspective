using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCheck : MonoBehaviour {

	public GameObject snapBlock;

    [SerializeField]
    private GameObject portal2;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "wordPosBox" && (GameObject.Find("Controller (left)").GetComponent<PickupParent> ().triggerUp || GameObject.Find("Controller (right)").GetComponent<PickupParent> ().triggerUp)) {
			this.gameObject.SetActive (false);
			snapBlock.SetActive (true);
            portal2.SetActive (true);
		}
	}
}
