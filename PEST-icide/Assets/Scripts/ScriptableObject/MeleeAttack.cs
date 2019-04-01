using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ## DEFUNCT SCRIPT - NO LONGER IN USE ##

[CreateAssetMenu(fileName = "New Melee Attack", menuName = "Melee Attack")]
public class MeleeAttack : ScriptableObject {

    public GameObject prefab;
    public string attackName;
    enum attackType { Jab, Sweep, Combination };
    public float damage;




}
