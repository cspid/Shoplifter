using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject mainScreen;
    public List<Material> materials = new List<Material>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //The numbers you can click are from 1 - 7, the first camera
        //starts from the left bottom side of the table.
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainScreen.GetComponent<MeshRenderer>().material = materials[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mainScreen.GetComponent<MeshRenderer>().material = materials[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            mainScreen.GetComponent<MeshRenderer>().material = materials[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mainScreen.GetComponent<MeshRenderer>().material = materials[3];
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mainScreen.GetComponent<MeshRenderer>().material = materials[4];

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            mainScreen.GetComponent<MeshRenderer>().material = materials[5];
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            mainScreen.GetComponent<MeshRenderer>().material = materials[6];
        }
    }
}
