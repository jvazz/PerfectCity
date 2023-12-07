using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject gameController;
    public List<GameObject> panels;
    //public List<GameObject> openedPanels;
    public List<Text> texts;
    bool pause = false;
    public Slider timeMultiplierSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = gameController.GetComponent<GameController>().money.ToString();
        texts[2].text = gameController.GetComponent<GameController>().population.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseManager(1);
        }

        Time.timeScale = timeMultiplierSlider.value/2;
    }

    public void OpenPanel(int panelNumber)
    {
        //openedPanels.Add(panels[panelNumber]);
        panels[panelNumber].SetActive(true);
    }

    public void ClosePanel(int panelNumber)
    {
        //openedPanels.Remove(panels[panelNumber]);
        panels[panelNumber].SetActive(false);
    }

    public void InformationBtn(string information)
    {
        texts[1].text = information;
    }

    public void PauseManager(int function)
    {
        if(function == 1)
        {
            if (pause){
                ClosePanel(1);
                pause = false;
                Time.timeScale = timeMultiplierSlider.value / 2;
                //Time.timeScale = 1;
            }
            else
            {
                OpenPanel(1);
                pause = true;
                Time.timeScale = 0;
            }
        }


        if(function == 2)
        {
            SceneManager.LoadScene("HomeMenu");
        }

        if (function == 3)
        {
            Application.Quit();
        }
    }
}
