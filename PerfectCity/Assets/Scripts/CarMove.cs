using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CarMove : MonoBehaviour
{
    public float velocity;
    public BaseSpawn baseSpawn;
    public int xpos, ypos;
    public bool moving;
    public Vector2 lastPosition;
    public Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        baseSpawn = GameObject.Find("GameController").GetComponent<BaseSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!moving)
        {
            List<Vector2> positions = new List<Vector2>();

            if(xpos < 19 && baseSpawn.grid[xpos + 1, ypos].myConstruction != null)
            {
                if (baseSpawn.grid[xpos + 1, ypos].myConstruction.gameObject.name.StartsWith("Street"))
                {
                    if (lastPosition != new Vector2(xpos + 1, ypos))
                        positions.Add(new Vector2(xpos + 1, ypos));
                }
            }
            if (xpos > 0 && baseSpawn.grid[xpos - 1, ypos].myConstruction != null)
            {
                if (baseSpawn.grid[xpos - 1, ypos].myConstruction.gameObject.name.StartsWith("Street"))
                {
                    if (lastPosition != new Vector2(xpos - 1, ypos))
                        positions.Add(new Vector2(xpos - 1, ypos));
                }
            }
            if (ypos < 19 && baseSpawn.grid[xpos, ypos + 1].myConstruction != null)
            {
                if (baseSpawn.grid[xpos, ypos + 1].myConstruction.gameObject.name.StartsWith("Street"))
                {
                    if (lastPosition != new Vector2(xpos, ypos + 1))
                        positions.Add(new Vector2(xpos, ypos + 1));
                }
            }
            if (ypos > 0 && baseSpawn.grid[xpos, ypos - 1].myConstruction != null)
            {
                if (baseSpawn.grid[xpos, ypos - 1].myConstruction.gameObject.name.StartsWith("Street"))
                {
                    if (lastPosition != new Vector2(xpos, ypos - 1))
                        positions.Add(new Vector2(xpos, ypos - 1));
                }
            }

            if (positions.Count == 0)
            {
                target = lastPosition;
            }
            if (positions.Count > 0)
            {
                int select = Random.Range(0, positions.Count);
                target = positions[select];
            }
            transform.LookAt(baseSpawn.grid[(int)target.x, (int)target.y].transform);
            moving = true;
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, baseSpawn.grid[(int)target.x, (int)target.y].transform.position, velocity * Time.deltaTime);
            if (Vector3.Distance(transform.position, baseSpawn.grid[(int)target.x, (int)target.y].transform.position) < 0.1f)
            {
                lastPosition = new Vector2(xpos, ypos);
                xpos = (int)target.x;
                ypos = (int)target.y;
                moving = false;
            }
        }
    }
}
