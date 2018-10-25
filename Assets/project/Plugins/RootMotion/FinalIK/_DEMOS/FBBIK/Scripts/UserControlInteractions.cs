using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;

namespace RootMotion.Demos {

	/// <summary>
	/// User control demo for Interaction Triggers.
	/// </summary>
	public class UserControlInteractions : UserControlThirdPerson {

		//[SerializeField] CharacterThirdPerson character;
		[SerializeField] InteractionSystem interactionSystem; // Reference to the InteractionSystem of the character
		[SerializeField] bool disableInputInInteraction = true; // If true, will keep the character stopped while an interaction is in progress
		public float enableInputAtProgress = 0.8f; // The normalized interaction progress after which the character is able to move again
        public HoldCheck holdCheck;
        string heldItemName;

        public Transform thisLeftHand;
        public Transform thisRightHand;

        protected override void Update() {

           
            // Disable input when in interaction
            if (disableInputInInteraction && interactionSystem != null && (interactionSystem.inInteraction || interactionSystem.IsPaused())) {

				// Get the least interaction progress
				float progress = interactionSystem.GetMinActiveProgress();

				// Keep the character in place
				if (progress > 0f && progress < enableInputAtProgress) {
					state.move = Vector3.zero;
					state.jump = false;
					return;
				}
			}

			// Pass on the FixedUpdate call
			base.Update();
		}

		// Triggering the interactions
		void OnGUI() {
			// If jumping or falling, do nothing
			//if (!character.onGround) return;

			// If an interaction is paused, resume on user input
			if (interactionSystem.IsPaused() && interactionSystem.IsInSync()) {
				GUILayout.Label("Press E to resume interaction");

				if (Input.GetKey(KeyCode.E)) {
					interactionSystem.ResumeAll();
				}

				return;
			}

			// If not paused, find the closest InteractionTrigger that the character is in contact with
			int closestTriggerIndex = interactionSystem.GetClosestTriggerIndex();

            if (Input.GetKey(KeyCode.L)){
                print(closestTriggerIndex);
            }

            // ...if none found, do nothing
            if (closestTriggerIndex == -1) return;

			// ...if the effectors associated with the trigger are in interaction, do nothing
			if (!interactionSystem.TriggerEffectorsReady(closestTriggerIndex)) return;

            // Its OK now to start the trigger
            if (holdCheck.holdingLeft == false && holdCheck.holdingRight == false && interactionSystem.GetClosestInteractionObjectInRange().transform.parent.name != "Placement Point") {
                GUILayout.Label("Press E to pick up " + interactionSystem.GetClosestInteractionObjectInRange().transform.parent.name);

                //set the hamds on ObjectTakeAnd Leave to this player's hands
                interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().leftHand = thisLeftHand;
                interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().rightHand = thisRightHand;
                /*
                //set the hand target by character type
                if (gameObject.name == "Fireman") 
                {
                    print(interactionSystem.GetClosestInteractionObjectInRange());
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().fireman = true;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().tankTop = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().hatGuy = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().trenchLady = false;
                }

                if (gameObject.name == "TankTop")
                {
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().tankTop = true;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().fireman = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().hatGuy = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().trenchLady = false;
                }

                if (gameObject.name == "TrenchLady")
                {
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().trenchLady = true;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().tankTop = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().fireman = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().hatGuy = false;
                }

                if (gameObject.name == "HatGuy")
                {
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().hatGuy = true;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().tankTop = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().fireman = false;
                    interactionSystem.GetClosestInteractionObjectInRange().transform.parent.gameObject.GetComponent<ObjectTakeAndLeave>().trenchLady = false;
                }
                */
            }

            if (holdCheck.holdingLeft == true && interactionSystem.GetClosestInteractionObjectInRange().name == "Interaction Object L Hand" && heldItemName != null){
                GUILayout.Label("Press E to put down " + heldItemName);
            }

            if (holdCheck.holdingRight == true && interactionSystem.GetClosestInteractionObjectInRange().name == "Interaction Object R Hand" && heldItemName != null)
            {
                GUILayout.Label("Press E to put down " + heldItemName);
            }

            //If we're not holding anything...
            if ((holdCheck.holdingLeft == false && holdCheck.holdingRight == false) || interactionSystem.GetClosestInteractionObjectInRange().transform.parent.name == "Placement Point")
            {
                if ((holdCheck.holdingLeft == false && holdCheck.holdingRight == false) || (holdCheck.holdingLeft == true && interactionSystem.GetClosestInteractionObjectInRange().name == "Interaction Object L Hand") || (holdCheck.holdingRight == true && interactionSystem.GetClosestInteractionObjectInRange().name == "Interaction Object R Hand"))
                {
                    //...pick up an item in range when we press the button
                    if (Input.GetKey(KeyCode.E) || Input.GetButton("MXButton0"))
                    {
                        interactionSystem.TriggerInteraction(closestTriggerIndex, false);
                        heldItemName = interactionSystem.GetClosestInteractionObjectInRange().transform.parent.name;
                    }
                }
            }
		}
	}
}
