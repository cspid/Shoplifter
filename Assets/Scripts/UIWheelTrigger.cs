using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWheelTrigger : MonoBehaviour
{


    float lerpTime = 1f;
    bool changeLevel;
    bool scaleUp;
    GameObject firstChild;
    public Transform rootSelector;
    float currentLerpTime = 0;
    Renderer rend;
    Color colorFade;
    public Material level1;
    public Material level2;
    public int thisLevel;


    void Start()
    {
        //Renderer rend = gameObject.GetComponent<Renderer>();


    }

    void Update()
    {
        //set in LevelUp()

        if (changeLevel == false){
            currentLerpTime = 0;

        }

        if (changeLevel == true)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
                ScaleUp();
                changeLevel = false;
            }

            float t = currentLerpTime;
           // t = Mathf.Sin(t * Mathf.PI * 0.5f);
            transform.position = Vector3.Lerp(transform.position, transform.root.position, t);
            transform.localScale = Vector3.Lerp(transform.localScale, rootSelector.localScale, t);

            //Renderer rend = gameObject.GetComponent<Renderer>();
            //rend.sharedMaterial.color = colorFade;

            level1.color = colorFade;
            colorFade.a = 1 + ((currentLerpTime / lerpTime) * -1);
            print(colorFade.a);
        }

        if (scaleUp == true)
        {
            //print("scale up");
            firstChild = transform.GetChild(0).gameObject;
            //lerp scale
            float currentLerpTime = 0f;

            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
                scaleUp = false;

            }

            float t = currentLerpTime;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            firstChild.transform.localScale = Vector3.Lerp(firstChild.transform.localScale, new Vector3(2.5f, 2.5f, 2.5f), t);

            level2.color = colorFade;
            colorFade.a = t;
            print(colorFade.a);
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Root Selector")
        {
            print("is root");
            if (Input.GetButtonDown("R3"))
            {
                LevelUp();
            }
        }
    }

    void ScaleUp(){
        scaleUp = true;

    }
    void Highlight(){

    }

    void LevelUp(){
        //lerp poition in update
        changeLevel = true;
        print("level up");
        Highlight();
            
                
            }
        }    
    
