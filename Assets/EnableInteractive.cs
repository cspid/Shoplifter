using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInteractive : MonoBehaviour
{
    public GameObject prefab;
    GameObject imported;
    public GameObject placement;
    Transform physicalObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13)
		{   
			print("jsdfhjkn"); 
            if (transform.childCount > 0) ;
                physicalObject = transform.GetChild(0);
                imported = Instantiate(prefab, transform);
                print("in");
                imported.transform.position = transform.position;
                imported.transform.rotation = transform.rotation;
                imported.GetComponent<ObjectTakeAndLeave>().placementPoint = placement;
                physicalObject.parent = imported.transform;
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (imported != null)
        {
            if (imported.transform.parent.name == "mixamorig:LeftHand" || imported.transform.parent.name == "mixamorig:RightHand")
            {
                imported.GetComponent<ObjectTakeAndLeave>().wasHeld = true;
                imported.transform.parent = null;
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 13 && imported.GetComponent<ObjectTakeAndLeave>().wasHeld == false)
        {
            print("out");
            if (transform.childCount > 0) Destroy(transform.GetChild(0).gameObject);
        }
    }



}
