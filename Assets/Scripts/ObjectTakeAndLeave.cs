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
	    public bool wasHeld;


        bool holdingRight;
        bool holdingLeft;

        
	    HoldCheck holdCheck;

	private void OnEnable()
	{
		if(GameObject.Find("placement holder").transform.GetChild(0).gameObject != null) placementPoint = GameObject.Find("placement holder").transform.GetChild(0).gameObject;
	}

	private void Start()
    {
        holdCheck = GameObject.FindWithTag("Player").GetComponent<HoldCheck>();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "range") holdCheck = other.transform.root.GetComponent<HoldCheck>();
	}

	void Update()
    {
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
	

