using UnityEngine;
using RootMotion.FinalIK;



public class ObjectTakeAndLeave : MonoBehaviour {

		public Transform leftHand;
		public Transform rightHand;
    
        public GameObject placementPoint;



        public bool fireman;
        public bool tankTop;
        public bool hatGuy;
        public bool trenchLady;




        public Transform firemanPivot;
        public Transform tankTopPivot;
        public Transform hatGuyPivot;
        public Transform trenchLadyPivot;



        bool holdingRight;
        bool holdingLeft;

        HoldCheck holdCheck;


    private void Start()
    {
        holdCheck = GameObject.FindWithTag("Player").GetComponent<HoldCheck>();
    }

     void Update()
    {
        //ensure only one is true
        if (fireman == true) {
            firemanPivot.gameObject.SetActive(true);
            tankTopPivot.gameObject.SetActive(false);
            hatGuyPivot.gameObject.SetActive(false);
            trenchLadyPivot.gameObject.SetActive(false);
        }

        if (tankTop == true)
        {
            tankTopPivot.gameObject.SetActive(true);
            firemanPivot.gameObject.SetActive(false);
            hatGuyPivot.gameObject.SetActive(false);
            trenchLadyPivot.gameObject.SetActive(false);
        }

        if (trenchLadyPivot == true)
        {
            trenchLadyPivot.gameObject.SetActive(true);
            hatGuyPivot.gameObject.SetActive(false);
            firemanPivot.gameObject.SetActive(false);
            tankTopPivot.gameObject.SetActive(false);
        }

        if (hatGuy == true)
        {
            hatGuyPivot.gameObject.SetActive(true);
            firemanPivot.gameObject.SetActive(false);
            tankTopPivot.gameObject.SetActive(false);
            trenchLadyPivot.gameObject.SetActive(false);
        }

    }

    // Called by the Interaction Object
    void OnPickUp()
        {
            StopAllCoroutines();
            //Reset Object after time (debugging)
            //StartCoroutine(ResetObject(Time.time + resetDelay));
        }

    void Holding(){

            //If the item is in the character's Left Hand
            if (gameObject.transform.parent == leftHand)
            {
                //Make the reachpoint active for player's Left Hand
                print("Holding Left");
                holdingLeft = true;
                holdCheck.holdingLeft = true;

        }
            //If the item is in the character's Right Hand
            if (gameObject.transform.parent == rightHand)
            {
                //Make the reachpoint active for player's Right Hand
                print("Holding Right");
                holdingRight = true;
                holdCheck.holdingRight = true;
        }

            if (holdingLeft == true || holdingRight == true)
            {
                placementPoint.SetActive(true);
            }

        }    		

   public void OnRelease(){
        if (gameObject.transform.parent == leftHand)
        {
            print("Releasing Left");
            holdingLeft = false;
            holdCheck.holdingLeft = false;
        }

        if (gameObject.transform.parent == rightHand)
        {
            print("Releasing Right");
            holdingRight = false;
            holdCheck.holdingRight = false;
        }

        if (holdingLeft == false && holdingRight == false){
            placementPoint.SetActive(false);
            print("Disabling Placement Point");
        }

        transform.parent = null;
    }
 
}
	

