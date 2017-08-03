using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUpdate : MonoBehaviour {

    private Animator portalAnimator;

    // Use this for initialization
    void Start() {
        portalAnimator = GetComponent<Animator>();
        portalAnimator.Play("Take 001");
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("trigger entered");
    }
}
