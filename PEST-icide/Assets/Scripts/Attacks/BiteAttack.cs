using UnityEngine;
using UnityEngine.Events;

public class BiteAttack : MonoBehaviour {

    private void Start()
    {
    
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter(Collider hit)
    {
        DynamicSoundAssignmentWrapper.loadSound(11);
        DynamicSoundAssignmentWrapper.playSound();
        Invoke("soundDestroy", 4);

        if (hit.gameObject.tag == "Player2")
        {
            Debug.Log("Player2 hit!");
        }
        else if (hit.gameObject.tag == "Player3")
        {
            Debug.Log("Player3 hit!");
        }
        else if (hit.gameObject.tag == "Player4")
        {
            Debug.Log("Player4 hit!");
        }

      
        //DynamicSoundAssignmentWrapper.destroySound();
    }

    private void soundDestroy()
    {

        DynamicSoundAssignmentWrapper.destroySound();
    }
}
