using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SittingPlacementArrayMaker : MonoBehaviour {

    //Do the hand placement nodes loop?
    public bool isLoop;
    //the placement nodes
    public Transform[] children;
    public Transform buttTarget;
    public GameObject leftHandTarget;
    public GameObject rightHandTarget;
    int buttTargetAsInt;
    string childNameAtStart;
    bool check;

    int i;

    // Use this for initialization
    void Start () {

        //children = GetComponentsInChildren<Transform>();

        foreach (Transform child in transform)
        {
            if (check == false) { 
                childNameAtStart = child.name;
                check = true;

        }
            child.name = i.ToString();
            i++;
        }

    }

    public void SetHandTargets () {
        //print("test");
        buttTargetAsInt = Convert.ToInt32(buttTarget.gameObject.name);
        foreach (Transform child in transform)
        {

            //print (childNameAtStart + 3);
            if (Convert.ToInt32(child.name) == buttTargetAsInt + 3){
                rightHandTarget.transform.forward = child.transform.TransformDirection(transform.forward);
                rightHandTarget.transform.position = child.transform.position;
                print("Right Hand" + child.name);
            }
            if (Convert.ToInt32(child.name) == buttTargetAsInt - 3)
            {
                leftHandTarget.transform.forward = child.transform.TransformDirection(transform.forward);
                leftHandTarget.transform.position = child.transform.position;
                print("Left Hand" + child.name);
            }
            i++;
        }
    }
}
