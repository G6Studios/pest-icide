using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour {

    Animator animator;
    private bool isActive;

    // Use this for initialization
    void Start () {
        animator = gameObject.GetComponent<Animator>();
        isActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(isActive == true)
        {
            animator.SetBool("trapBool", true);
        }

        else if(isActive == false)
        {
            animator.SetBool("trapBool", false);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (isActive)
        {
            other.gameObject.GetComponent<Player>().TakeDamage(1);
        }
    }

    public bool IsActive
    {
        set { isActive = value; }
        get { return isActive; }
    }


}
