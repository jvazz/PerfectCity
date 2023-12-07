using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public int dimensions;
    public GameObject platform;
    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(platform, new Vector3(0, 0, 0), Quaternion.identity);
        if (PlayerPrefs.GetInt("platformNumberX") < dimensions)
        {
            Instantiate(platform, new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), Quaternion.identity);
            PlayerPrefs.SetInt("platformNumberX", PlayerPrefs.GetInt("platformNumberX") + 1);
        }
        if(!done && PlayerPrefs.GetInt("platformNumberX") >= dimensions && transform.position.z < dimensions*9)
        {
            Instantiate(platform, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), Quaternion.identity);
            PlayerPrefs.SetInt("platformNumberZ", PlayerPrefs.GetInt("platformNumberZ") + 1);
            done = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!done && PlayerPrefs.GetInt("platformNumberX") >= dimensions && transform.position.z < dimensions*10)
        {
            Instantiate(platform, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), Quaternion.identity);
            PlayerPrefs.SetInt("platformNumberZ", PlayerPrefs.GetInt("platformNumberZ") + 1);
            done = true;
        }
    }
}
