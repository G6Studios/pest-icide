using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Power up interface
public interface IPowerUp
{
    void PickUp(Collider other);

}

//If our powerUp applies an effect for a duration
// We need to create a coruntine function call and wrap it in pickup
/*Ex.
 * Void PickUp(Collider other)
 * {
 * Start Coruntine(TimedPickUp(other));
 * }
 * 
 * IEnumerator TimedPickUp(Collider other)
 * {
 *  // Power up code here
 *  // Disable Powerup collider here
 *  // yield return new waitForSeconds()
 *  // Destory gameobject
 * }
 * 
 */
