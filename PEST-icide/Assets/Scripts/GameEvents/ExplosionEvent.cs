using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEvent : MonoBehaviour
{
    public ParticleSystem particles;

    private void OnTriggerEnter(Collider other)
    {
        particles.Play();
        other.GetComponent<Player>().health -= 10;
    }


}
