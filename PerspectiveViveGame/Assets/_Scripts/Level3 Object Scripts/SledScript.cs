using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SledScript : MonoBehaviour {

	public Animator winterAnim;
    private GameObject painting;
	CheckPerspective3 checkP;
    public Collider[] colliders;

    [SerializeField]
    public Material[] mat = new Material[11];

    // Use this for initialization
    void Start () {
        colliders = GetComponents<Collider>();
        checkP = GameObject.Find ("Camera (eye)").GetComponent<CheckPerspective3> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "winterPainting") {
            painting = other.gameObject;
            StartCoroutine("AnimatePainting");
			EndGame.winterSolved = true;
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            // NEXT LINE SHOULD ACTIVATE WINTER PAINTING ANIMATION
            //winterAnim.SetBool("SledGiven", true);
            transform.position = new Vector3(10f, 0f, 0f);
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }
        }
	}

    IEnumerator AnimatePainting()
    {
        for (float f = 0; f < 11; f++)
        {
            painting.GetComponent<Renderer>().material = mat[(int)f];
            Debug.Log("coroutine running!");
            yield return new WaitForSeconds(.5f);
        }
    }
}
