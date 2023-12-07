using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetSide : MonoBehaviour
{
    public GameObject lateral;

    // Start is called before the first frame update
    void Start()
    {
        lateral = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Street")
        {
            lateral.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Street")
        {
            lateral.SetActive(true);
        }
    }
}
