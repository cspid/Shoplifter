using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPcheck : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay (Collider other) {
        if (other.gameObject.tag == "Interactive")
        {
            print("interactive");
            gameObject.layer = 0;
        } else {
            gameObject.layer = 8;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
