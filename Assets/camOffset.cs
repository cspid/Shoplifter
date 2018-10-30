using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camOffset : MonoBehaviour {

	public Transform target;
	public float xMod;
	public float yMod;
	public float zMod;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.position.x + xMod, target.position.y + yMod, target.position.z + zMod);
	}
}
