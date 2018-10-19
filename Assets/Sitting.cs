using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitting : MonoBehaviour {


    float nearestDistance = 1000f;
    float distance = 0f;
    int layerMask = 1 << 8; //Layer 8
    float buttVisSphereRadius;
    //public SittingPlacementArrayMaker sittingPlacementScript;
    public GameObject buttVisSphere;
    public GameObject buttTarget;

    //The Thing we are litting on
    public GameObject seat;


    void Start()
    {
        buttVisSphereRadius = buttVisSphere.gameObject.transform.localScale.y / 2;
    }

    public void RunButtCheck(){
        CheckPlacement(buttVisSphere.transform.position, buttVisSphereRadius, layerMask);
    }

    //butt
    void CheckPlacement(Vector3 center, float radius, int layer)
    {
        //print("Test");
        distance = 0;
        nearestDistance = 1000f;
        Collider[] PPinRange = Physics.OverlapSphere(center, radius, layer);
        //print(PPinRange.Length);

        int i = 0;
        while (i < PPinRange.Length)
        {
            distance = (buttVisSphere.transform.position - PPinRange[i].gameObject.transform.position).sqrMagnitude;
            //print("distance " + distance + "nearestDistance " + nearestDistance);

            if(PPinRange[i].gameObject.tag == "Sitting PP"){
                if (distance < nearestDistance)
                {
                    //print(PPinRange[i].gameObject.name);
                    nearestDistance = distance;
                    buttTarget.transform.SetPositionAndRotation(PPinRange[i].gameObject.transform.position, PPinRange[i].gameObject.transform.rotation);
                    PPinRange[i].gameObject.transform.parent.GetComponent<SittingPlacementArrayMaker>().buttTarget = PPinRange[i].gameObject.transform;
                    PPinRange[i].gameObject.transform.parent.GetComponent<SittingPlacementArrayMaker>().SetHandTargets();
                }
            }

            i++;
            //reachPoint.transform.position = targetPos.position;
        }

    }
}
