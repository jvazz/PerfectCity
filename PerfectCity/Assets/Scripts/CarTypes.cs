using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTypes : MonoBehaviour
{
    public List<GameObject> types;
    public int maxNumber;

    // Start is called before the first frame update
    void Start()
    {
        maxNumber = types.Count;
        types[Random.Range(0, maxNumber)].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
