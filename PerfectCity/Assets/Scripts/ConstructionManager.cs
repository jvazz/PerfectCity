using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    public bool constructionMode;
    public bool demolitionMode;
    public string constructionType;
    public List<GameObject> trasnparentStructures;
    public List<GameObject> normalStructures;

    // Start is called before the first frame update
    void Start()
    {
        constructionMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        { 
            constructionMode = !constructionMode;
        }
        /*if(constructionMode)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                constructionType = "street";
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                constructionType = "plantation";
            }
        }*/
    }

    public void ConstructionModeBtn(bool state)
    {
        constructionMode = state;
        demolitionMode = false;
        gameObject.GetComponent<PriceController>().PricesVerification();
    }

    public void ConstructionTypeBtn(string constructionTypeBtn)
    {
        constructionMode = true;
        constructionType = constructionTypeBtn;
    }

    public void DemolitionModeBtn(bool state)
    {
        demolitionMode = state;
        constructionMode = false;
    }

}
