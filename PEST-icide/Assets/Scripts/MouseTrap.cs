using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();
        animator.StartPlayback();
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}
}
