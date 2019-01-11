using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Attack", menuName = "Ranged Attack")]
public class RangedAttack : ScriptableObject {

    public GameObject prefab;
    public string attackName;
    enum attackType { Hitscan, LinearProjectile, ArcProjectile };
    public float damage;

}
