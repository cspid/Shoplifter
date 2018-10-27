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
    public InteractionObject examinePointL;
	public InteractionObject examinePointR;
	public InteractionObject pocketL;
	public InteractionObject pocketR;


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
			if (Input.GetButton("MXButton2"))
			{
				print("steal");                   
				interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, pocketL, interrupt);
				holdingLeft = false;
			}
            if (Input.GetButton("MXButton1")) print("butt");
            //Look at Object
            if (isLooking == false && Input.GetKey(KeyCode.R) || Input.GetButton("MXButton1")) /*|| Input.GetButton("MXButton0")*/
            {
                interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, examinePointL, interrupt);
            }
            if (isLooking == true && Input.GetKey(KeyCode.R) || Input.GetButton("MXButton0") || Input.GetButton("MXButton1")) /*|| Input.GetButton("MXButton0")*/
            {
                interactionSystem.ResumeInteraction(FullBodyBipedEffector.LeftHand);
                isLooking = false;
                //Steal Object

            }

        }
        else
        {
            //interactionObjR.SetActive(true);
        }

        if (holdingRight == true)
        {
			if (Input.GetButton("MXButton2")){
				print("steal");
				interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, pocketR, interrupt);
			}
            if (isLooking == false && Input.GetKey(KeyCode.R) /*|| Input.GetButton("MXButton0")*/)
            {
                interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, examinePointR, interrupt);
            }
            if (isLooking == true && Input.GetKey(KeyCode.R) /*|| Input.GetButton("MXButton0")*/)
            {
                interactionSystem.ResumeInteraction(FullBodyBipedEffector.RightHand);
                isLooking = false;
                //Steal Object

            }
        }
        else
        {
           //interactionObjL.SetActive(true);
        }
    }

}
