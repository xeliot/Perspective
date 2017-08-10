using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaScript : MonoBehaviour {

	public Animator springAnim;
	private GameObject painting;
    public Collider[] colliders;
	CheckPerspective3 checkP;

    [SerializeField]
	Material[] mat = new Material[14];

	// Use this for initialization
	void Start () {
        colliders = GetComponents<Collider>();
		checkP = GameObject.Find ("Camera (eye)").GetComponent<CheckPerspective3> ();
    }
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "springPainting") {
			painting = other.gameObject;
			StartCoroutine("AnimatePainting");
			EndGame.springSolved = true;
            //gameObject.SetActive (false);
            // NEXT LINE SHOULD ACTIVATE SPRING PAINTING ANIMATION
            //springAnim.SetBool("UmbrellaGiven", true);
            transform.position = new Vector3(10f, 0f, 0f);
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
	}

	IEnumerator AnimatePainting()
	{
		for (float f = 0; f < 14; f++) {
			painting.GetComponent<Renderer>().material = mat[(int)f];
			yield return new WaitForSeconds (.5f);
		}
	}
}
