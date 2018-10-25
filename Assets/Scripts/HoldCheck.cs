using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;


public class HoldCheck : MonoBehaviour {


    public bool holdingRight;
    public bool holdingLeft;



    //interaction objects
    public GameObject interactionObjL;
    public GameObject interactionObjR;

    public InteractionSystem interactionSystem;
    public bool interrupt;
    public InteractionObject examinePoint;
    public bool isLooking;

    // Use this for initialization
    public void IsLooking () {
        if (isLooking == true) isLooking = false;
        if (isLooking == false) isLooking = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (holdingLeft == true)
        {
            ////interactionObjR.SetActive(false);
            if (isLooking == false && Input.GetKey(KeyCode.R) /*|| Input.GetButton("MXButton0")*/)
            {
                interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, examinePoint, interrupt);
            }
            if (isLooking == true && Input.GetKey(KeyCode.R) /*|| Input.GetButton("MXButton0")*/)
            {
                interactionSystem.ResumeInteraction(FullBodyBipedEffector.LeftHand);
                isLooking = false;
            }
        }
        else
        {
            //interactionObjR.SetActive(true);
        }

        if (holdingRight == true)
        {
            if (isLooking == false && Input.GetKey(KeyCode.R) /*|| Input.GetButton("MXButton0")*/)
            {
                interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, examinePoint, interrupt);
            }
            if (isLooking == true && Input.GetKey(KeyCode.R) /*|| Input.GetButton("MXButton0")*/)
            {
                interactionSystem.ResumeInteraction(FullBodyBipedEffector.RightHand);
                isLooking = false;
            }
        }
        else
        {
           //interactionObjL.SetActive(true);
        }
    }

}
