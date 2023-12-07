using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float money, population;
    public GameObject platform;
    public GameObject canva;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("platformNumberX", 0);
        PlayerPrefs.SetInt("platformNumberZ", 0);
        //Debug.Log(PlayerPrefs.GetInt("platformNumberX"));
        //Instantiate(platform, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.K))
        {
            ChangeMoney(10000);
        }
    }

    public void ChangeMoney(float value)
    {
        money += value;
        gameObject.GetComponent<PriceController>().PricesVerification();
    }
}
