using UnityEngine;
using UnityEngine.Events;

public class ScratchAttack : MonoBehaviour {

    private float attackFrames;

    // For event
    private UnityAction scratchAttack;

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player2")
        {
            Debug.Log("Player2 hit!");
        }
        else if(hit.gameObject.tag == "Player3")
        {
            Debug.Log("Player3 hit!");
        }
        else if(hit.gameObject.tag == "Player4")
        {
            Debug.Log("Player4 hit!");
        }

    }

}
