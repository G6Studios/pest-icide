using UnityEngine;
using UnityEngine.Events;

public class ScratchAttack : MonoBehaviour {

    private float attackFrames;

    // For event
    private UnityAction scratchAttack;

	// Use this for initialization
	void OnEnable () {

        EventManager.instance.StartListening("scratchAttack", scratchAttack);


	}


    private void Awake()
    {
        scratchAttack = new UnityAction(scratch);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag == "Dummy")
        {
            Debug.Log("Hit!");
        }

    }

    private void Update()
    {
        if(attackFrames > 0)
        {
            attackFrames -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void scratch()
    {
        attackFrames += 1.0f;

    }

}
