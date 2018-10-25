using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWheel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(Input.GetAxis("Horizontal Right Stick"), Input.GetAxis("Vertical Right Stick"), transform.localPosition.z);
	}
}
