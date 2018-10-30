using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceOnEnter : MonoBehaviour {

	public GameObject prefab;
	public GameObject instantiated;
	public GameObject character;
	bool isEntered;

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer == 13 && isEntered == false)
		{
			isEntered = true;
			character = other.gameObject;
			//GetComponent<MeshRenderer>().enabled = false;
			for (int i = 0; i < transform.childCount; i++)
			{
				print(transform.childCount);
				transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;
			}

			instantiated = Instantiate(prefab, transform.position, transform.rotation);
		}
	}
    
	void OnTriggerExit(Collider other)
    {
		if (other.gameObject.layer == 13 && other.gameObject == character && isEntered == true)
        {
			isEntered = false;
            //GetComponent<MeshRenderer>().enabled = false;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
				Destroy(instantiated);
            }
        }
	}
}
