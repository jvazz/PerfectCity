using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceController : MonoBehaviour
{
    public List<Button> buttons;
    public List<float> prices;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PricesVerification()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (gameObject.GetComponent<GameController>().money >= prices[i])
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
}
