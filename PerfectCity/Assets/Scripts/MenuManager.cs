using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject configPanel, aboutPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuBtns(int function)
    {
        if(function == 1)
            SceneManager.LoadScene("SampleScene");

        if (function == 2)
            configPanel.SetActive(true);

        if (function == 3)
            aboutPanel.SetActive(true);

        if (function == 4)
            Application.Quit();

        if (function == 5)
            configPanel.SetActive(false);

        if (function == 6)
            aboutPanel.SetActive(false);
    }
}
