using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialStreetPlataform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ConstructionSpace>().myConstruction.name.StartsWith("Street"))
        {
            gameObject.GetComponent<ConstructionSpace>().myConstruction = other.gameObject.GetComponent<ConstructionSpace>().myConstruction;
        }
    }
}
