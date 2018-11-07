using UnityEngine;
using UnityEngine.Events;

public class ScratchAttack : MonoBehaviour {

    private float attackFrames;

    // For event
    private UnityAction scratchAttack;

    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Dummy")
        {
            Debug.Log("Hit!");
        }

    }

}
