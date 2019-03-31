using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ## DEFUNCT SCRIPT - NO LONGER IN USE ##

public class PoisonShot : MonoBehaviour {

    [SerializeField]
    private Transform firePoint;

    public Rigidbody prefab;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("B_P1"))
        {
            DynamicSoundAssignmentWrapper.loadSound(31);
            FirePoison();
            DynamicSoundAssignmentWrapper.playSound();
            Invoke("soundDestroy", 4);
        }
	}

    public void FirePoison()
    {
        var poisonInstance = Instantiate(prefab, firePoint.position, firePoint.rotation);

        poisonInstance.AddForce(firePoint.forward * 700.0f);
    }

    private void soundDestroy()
    {
        DynamicSoundAssignmentWrapper.destroySound();
    }

}
 