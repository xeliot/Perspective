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
		public GameObject keyGroup;
		public Animator keyAnim;
		public GameObject particles;

		void Start()
		{
		}

		private void OnTriggerEnter( Collider other)
		{
			if (other.tag == "keyhole") {
				this.gameObject.SetActive (false);
				keyGroup.SetActive (true);
				CheckPerspective.keyInHole = true;
				keyAnim.SetBool ("KeyInserted", true);
				particles.SetActive (true);
				particles.GetComponent<ParticleSystem> ().Play();
			}
		}
	}
}
