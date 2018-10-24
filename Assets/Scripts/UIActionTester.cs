using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;



/// <summary>
/// Simple demo controller for the InteractionSystem.
/// </summary>
public class UIActionTester : MonoBehaviour
{


    public Transform rightThighBendTarget;
    public Transform leftThighBendTarget;
    public InteractionSystem interactionSystem; // Reference to the InteractionSystem of the character
    public bool interrupt; // Can we interrupt an interaction of an effector?
    //public Sitting sitting;

    // The interaction objects
    public InteractionObject ball, sittingMain, sittingLeftHand, sittingRightHand, cigarette, door;
    bool isSitting;



    void Update()
    {
       // sitting.RunButtCheck();
        interactionSystem.ik.solver.rightLegChain.bendConstraint.weight = interactionSystem.ik.solver.bodyEffector.positionWeight;
        interactionSystem.ik.solver.leftLegChain.bendConstraint.weight = interactionSystem.ik.solver.bodyEffector.positionWeight;

        if (isSitting)
        {
            
            if (!interactionSystem.inInteraction && Input.GetButtonDown("WXButton1"))
            {
                interactionSystem.ResumeAll();
                
                isSitting = false;
            }
            
            return;
        }
        
        if (!interactionSystem.inInteraction && Input.GetButtonDown("WXButton1"))
        {
            print("test");
           //sitting.RunButtCheck();
            //Body
            interactionSystem.StartInteraction(FullBodyBipedEffector.Body, sittingMain, interrupt);
            //Left Leg
            //interactionSystem.StartInteraction(FullBodyBipedEffector.LeftThigh, sittingMain, interrupt);
            interactionSystem.ik.solver.leftLegChain.bendConstraint.bendGoal = leftThighBendTarget;
            interactionSystem.ik.solver.leftLegChain.bendConstraint.weight = interactionSystem.ik.solver.bodyEffector.positionWeight;
            //Right Leg
            //interactionSystem.StartInteraction(FullBodyBipedEffector.RightThigh, sittingMain, interrupt);
            interactionSystem.ik.solver.rightLegChain.bendConstraint.bendGoal = rightThighBendTarget;
            interactionSystem.ik.solver.rightLegChain.bendConstraint.weight = interactionSystem.ik.solver.bodyEffector.positionWeight;

            //Left Hand
            interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, sittingLeftHand, interrupt);
            //RightnHand
            interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, sittingRightHand, interrupt);

            //interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, benchHands, interrupt);

            isSitting = true;
        }


    }
    // GUI for calling the interactions
    void OnGUI()
    {
        interrupt = GUILayout.Toggle(interrupt, "Interrupt");

        // While seated
        if (isSitting)
        {

            if (!interactionSystem.inInteraction && GUILayout.Button("Stand Up"))
            {
                interactionSystem.ResumeAll();

                isSitting = false;
            }

            return;
        }

    

        //Sitting
        if (!interactionSystem.inInteraction && GUILayout.Button("Sit Down"))
        {
            print("test");
//            sitting.RunButtCheck();
            //Body
            interactionSystem.StartInteraction(FullBodyBipedEffector.Body, sittingMain, interrupt);
            //Left Leg
            //interactionSystem.StartInteraction(FullBodyBipedEffector.LeftThigh, sittingMain, interrupt);
            interactionSystem.ik.solver.leftLegChain.bendConstraint.bendGoal = leftThighBendTarget;
            interactionSystem.ik.solver.leftLegChain.bendConstraint.weight = interactionSystem.ik.solver.bodyEffector.positionWeight;
            //Right Leg
            //interactionSystem.StartInteraction(FullBodyBipedEffector.RightThigh, sittingMain, interrupt);
            interactionSystem.ik.solver.rightLegChain.bendConstraint.bendGoal = rightThighBendTarget;
            interactionSystem.ik.solver.rightLegChain.bendConstraint.weight = interactionSystem.ik.solver.bodyEffector.positionWeight;

            //Left Hand
            interactionSystem.StartInteraction(FullBodyBipedEffector.LeftHand, sittingLeftHand, interrupt);
            //RightnHand
            interactionSystem.StartInteraction(FullBodyBipedEffector.RightHand, sittingRightHand, interrupt);

            isSitting = true;
        }
    }
}