using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour {

	CheckPerspective3 checkP;
	private GameObject painting;
    public Collider[] colliders;

    [SerializeField]
	public Material[] mat = new Material[12];

	public Animator summerAnim;

    void Start()
    {
        colliders = GetComponents<Collider>();
    }

    void Update () {
		checkP = GameObject.Find ("Camera (eye)").GetComponent<CheckPerspective3> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "summerPainting") {
			//gameObject.SetActive (false);
			//summerAnim.SetBool ("BucketGiven", true);
			painting = other.gameObject;

			if (EndGame.summerBool) {
				// NEXT LINE SHOULD ACTIVATE SUMMER PAINTING ANIMATION
				StartCoroutine("AnimatePainting");
				EndGame.summerSolved = true;
			} else {
				EndGame.summerBool = true;
			}
            transform.position = new Vector3(10f, 0f, 0f);
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
	}
	IEnumerator AnimatePainting()
	{
		for (float f = 0; f < 12; f++) {
			painting.GetComponent<Renderer>().material = mat[(int)f];
			Debug.Log ("coroutine running!");
			yield return new WaitForSeconds (.5f);
		}
	}
}
