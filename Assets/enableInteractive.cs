using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableInteractive : MonoBehaviour
{
	public GameObject prefab;
	GameObject imported;


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			print("in");
			imported = Instantiate(prefab, transform);
			imported.transform.position = transform.position;
			imported.transform.rotation = transform.rotation;


            
		}

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == 13) 
		{
			print("out");
			Destroy(transform.GetChild(0).gameObject); 
		}
	}   



}
