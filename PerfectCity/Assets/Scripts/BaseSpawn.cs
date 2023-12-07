using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawn : MonoBehaviour
{ 
    public GameObject plataform;
    public ConstructionSpace[,] grid = new ConstructionSpace[20,20];

    public GameObject carroTemporario;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameObject myPlataform = Instantiate(plataform, new Vector3(i*10, 0, j*10), Quaternion.identity);
                myPlataform.GetComponent<ConstructionSpace>().xpos = i;
                myPlataform.GetComponent<ConstructionSpace>().ypos = j;
                grid[i, j] = myPlataform.GetComponent<ConstructionSpace>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            GameObject car = Instantiate(carroTemporario, grid[0,0].transform.position, Quaternion.identity);
            car.GetComponent<CarMove>().xpos = 0;
            car.GetComponent<CarMove>().ypos = 0;
        }
    }
}
