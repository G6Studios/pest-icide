using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonShot : MonoBehaviour {

    [SerializeField]
    private Transform firePoint;

    public Rigidbody prefab;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("f"))
        {
            FirePoison();
        }
	}

    public void FirePoison()
    {
        var poisonInstance = Instantiate(prefab, firePoint.position, firePoint.rotation);

        poisonInstance.AddForce(firePoint.forward * 700.0f);
    }

}
 