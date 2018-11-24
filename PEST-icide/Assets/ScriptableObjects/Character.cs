using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject {

    public string characterName; // Name of character
    public float speed; // Movement speed of character
    public float jumpHeight; // Jump height of character
    public float jumpLength; // Jump length of character
    public Mesh mesh; // Character mesh
    public Collider collider; // The collider for the character
    public Rigidbody rigidbody; // The rigidbody for the character
    public Material material; // The material/texture for the character
    public Vector3 colliderOffset;
    public Vector3 colliderSize;

}
