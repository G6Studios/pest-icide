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
            Spider.instance.SendMessage("takeDamage", 3.0f);
        }
        else if(hit.gameObject.tag == "Player3")
        {
            Debug.Log("Player3 hit!");
            Frog.instance.SendMessage("takeDamage", 3.0f);
        }
        else if(hit.gameObject.tag == "Player4")
        {
            Debug.Log("Player4 hit!");
            Snake.instance.SendMessage("takeDamage", 3.0f);
        }
        DynamicSoundAssignmentWrapper.destroySound();

    }

}
