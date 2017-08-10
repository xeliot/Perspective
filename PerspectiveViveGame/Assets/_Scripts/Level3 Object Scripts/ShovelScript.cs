using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour {

	private GameObject painting;
	CheckPerspective3 checkP;
    public Collider[] colliders;

    [SerializeField]
	public Material[] mat = new Material[12];

	public Animator summerAnim;
	// Use this for initialization
	void Start () {
        colliders = GetComponents<Collider>();
        checkP = GameObject.Find ("Camera (eye)").GetComponent<CheckPerspective3> ();
	}

	public static void SetSummerBool(bool input)
	{
		EndGame.summerBool = input;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "summerPainting") {
			painting = other.gameObject;
			//summerAnim.SetBool ("ShovelGiven", true);
			if (EndGame.summerBool) {
				StartCoroutine ("AnimatePainting");
				EndGame.summerSolved = true;
				gameObject.GetComponent<MeshRenderer>().enabled = false;
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
