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
		public GameObject heldObject;

        public Transform thisLeftHand;
        public Transform thisRightHand;

		public bool aiCanGrab;

        //when we steeeeal
		public void Stolen()
        {
			Destroy(heldObject);
			holdCheck.interactionObjL.transform.parent.gameObject.SetActive(false);
			holdCheck.holdingLeft = false;
			holdCheck.holdingLeft = true;
			print (holdCheck.interactionObjL.transform.parent.name);
        }

	
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
                    //...pick up an item in range when we press the button or the ai script says to
					if (Input.GetKey(KeyCode.E) || Input.GetButton("MXButton0") || aiCanGrab == true)
                    {
                        interactionSystem.TriggerInteraction(closestTriggerIndex, false);
                        heldItemName = interactionSystem.GetClosestInteractionObjectInRange().transform.parent.name;
						heldObject = interactionSystem.GetClosestInteractionObjectInRange().transform.parent.root.gameObject;
						aiCanGrab = false;
                    }
                }
            }
		}
	}
}
