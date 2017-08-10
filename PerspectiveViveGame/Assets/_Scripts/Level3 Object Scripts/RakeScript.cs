using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakeScript : MonoBehaviour {

	public Animator fallAnim;
	public GameObject painting;
    public Renderer rend;
    public Collider[] colliders;

	CheckPerspective3 checkP;

	[SerializeField]
	public Material[] mat = new Material[11];
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        colliders = GetComponents<Collider>();
		checkP = GameObject.Find ("Camera (eye)").GetComponent<CheckPerspective3> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "fallPainting") {
			//gameObject.SetActive (false);
			// NEXT LINE SHOULD ACTIVATE FALL PAINTING ANIMATION
			//fallAnim.SetBool("RakeGiven", true);
			painting = other.gameObject;
			StartCoroutine ("AnimatePainting");
			EndGame.fallSolved = true;
            //rend.enabled = false;
            transform.position = new Vector3(10f, 0f, 0f);
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
	}

	IEnumerator AnimatePainting()
	{
		for (float f = 0; f < 11; f++) {
			painting.GetComponent<Renderer>().material = mat[(int)f];
			yield return new WaitForSeconds (.5f);
		}
	}
}
