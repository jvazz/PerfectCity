using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public BaseSpawn baseSpawn;
    public int xpos, ypos;
    public bool spawned;
    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        baseSpawn = GameObject.Find("GameController").GetComponent<BaseSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            List<Vector2> positions = new List<Vector2>();

            if (xpos < 20 && baseSpawn.grid[xpos + 1, ypos].myConstruction != null)
            {
                if (baseSpawn.grid[xpos + 1, ypos].myConstruction.gameObject.name.StartsWith("Street"))
                { 
                        positions.Add(new Vector2(xpos + 1, ypos));
                }
            }
            if (xpos > 0 && baseSpawn.grid[xpos - 1, ypos].myConstruction != null)
            {
                if (baseSpawn.grid[xpos - 1, ypos].myConstruction.gameObject.name.StartsWith("Street"))
                {
                        positions.Add(new Vector2(xpos - 1, ypos));
                }
            }
            if (ypos < 20 && baseSpawn.grid[xpos, ypos + 1].myConstruction != null)
            {
                if (baseSpawn.grid[xpos, ypos + 1].myConstruction.gameObject.name.StartsWith("Street"))
                {
                        positions.Add(new Vector2(xpos, ypos + 1));
                }
            }
            if (ypos > 0 && baseSpawn.grid[xpos, ypos - 1].myConstruction != null)
            {
                if (baseSpawn.grid[xpos, ypos - 1].myConstruction.gameObject.name.StartsWith("Street"))
                {
                        positions.Add(new Vector2(xpos, ypos - 1));
                }
            }

            if (positions.Count > 0)
            {
                int select = Random.Range(0, positions.Count);
                int x, y;
                x = (int)positions[select].x;
                y = (int)positions[select].y;
                GameObject createdCar = Instantiate(car, baseSpawn.grid[x, y].transform.position, Quaternion.identity);
                createdCar.GetComponent<CarMove>().xpos = x;
                createdCar.GetComponent<CarMove>().ypos = y;
                spawned = true;
            }
        }
    }
}
