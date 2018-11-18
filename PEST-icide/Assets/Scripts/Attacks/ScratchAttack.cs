using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;

public class ScratchAttack : MonoBehaviour {


    private void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter(Collider hit)
    {
        DynamicSoundAssignmentWrapper.loadSound(12);
        DynamicSoundAssignmentWrapper.playSound();
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
        DynamicSoundAssignmentWrapper.destroySound();

    }

}
