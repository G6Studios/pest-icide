using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeKeyCave : MonoBehaviour {

    SkinnedMeshRenderer mesh;

	// Use this for initialization
	void Start () {
        mesh = gameObject.GetComponent<SkinnedMeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float random;
        random = Mathf.Abs((Mathf.Sin(Time.time) * 100));

        mesh.SetBlendShapeWeight(0, random);

	}
}
