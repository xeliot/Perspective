//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
    public class KeyScript : MonoBehaviour
	{
        AudioSource audiosource;

		public GameObject keyGroup;
		public Animator keyAnim;

        [SerializeField]
        private AudioClip keyClick;


		void Start()
		{
            audiosource = GetComponent<AudioSource>();
            //Debug.Log(audiosource);
		}

		private void OnTriggerEnter( Collider other)
		{
			if (other.tag == "keyhole") {
                Debug.Log("inserted into keyhole");
				this.gameObject.SetActive (false);
				keyGroup.SetActive (true);
				CheckPerspective.keyInHole = true;
				keyAnim.SetBool ("KeyInserted", true);
                audiosource.clip = keyClick;
                audiosource.Play();
			}
		}
	}
}
