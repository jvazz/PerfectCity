using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour
{
    public List<GameObject> streetsBad, streetsClean, plantationsBad, plantationsClean, housesBad, housesClean, recyclersBad, recyclersClean, storesBad, storesClean, schoolBad, schoolClean, hospitalBad, hospitalClean, treeBad, treeClean, factoryBad, factoryClean;
    public float food, gases, education, health;
    public List<Slider> sliderList;
    public Text moneyPerformanceTxt;
    public List<GameObject> onuObjectives;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CityPay", 60f, 60f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<GameController>().population > 0)
        {
            if (gameObject.GetComponent<GameController>().population * 10 > plantationsBad.Count * 10 + plantationsClean.Count * 10 + storesBad.Count * 50 + storesClean.Count * 50)
            {
                moneyPerformanceTxt.text = "$: " + ((plantationsBad.Count * 10 + plantationsClean.Count * 10 + storesBad.Count * 50 + storesClean.Count * 50 + factoryBad.Count * 20 + factoryClean.Count * 20) * Time.timeScale).ToString() + "/min";
            }
            else
            {
                moneyPerformanceTxt.text = "$: " + ((gameObject.GetComponent<GameController>().population * 10) * Time.timeScale).ToString() + "/min";
            }
            //moneyPerformanceTxt.text = "$: " + ((plantationsBad.Count * 10 + plantationsClean.Count * 10 + storesBad.Count * 50 + storesClean.Count * 50 + factoryBad.Count * 20 + factoryClean.Count * 20) * Time.timeScale).ToString() + "/min";
        }
        CheckObjectives();
    }

    void CityPay()
    {
        if (gameObject.GetComponent<GameController>().population >= 0)
        {
            if(gameObject.GetComponent<GameController>().population * 10 > plantationsBad.Count * 10 + plantationsClean.Count * 10 + storesBad.Count * 50 + storesClean.Count * 50)
            {
                gameObject.GetComponent<GameController>().ChangeMoney(plantationsBad.Count * 10 + plantationsClean.Count * 10 + storesBad.Count * 50 + storesClean.Count * 50);
            }else
            {
                gameObject.GetComponent<GameController>().ChangeMoney(gameObject.GetComponent<GameController>().population * 10);
            }
            //gameObject.GetComponent<GameController>().ChangeMoney(plantationsBad.Count * 10 + plantationsClean.Count * 10 + storesBad.Count * 50 + storesClean.Count * 50);
            gameObject.GetComponent<PriceController>().PricesVerification();
        }
        CheckObjectives();
    }

    public void CheckObjectives()
    {
        sliderList[0].maxValue = gameObject.GetComponent<GameController>().population;
        food = plantationsBad.Count * 20 + plantationsClean.Count * 20;
        sliderList[0].value = food;

        gases = plantationsBad.Count * 5 + housesBad.Count * 5 + recyclersBad.Count * 5 + storesBad.Count * 5 + schoolBad.Count * 5 + schoolBad.Count * 5 + hospitalBad.Count * 5 + hospitalBad.Count * 5 + factoryBad.Count * 5 - treeBad.Count * 5 - treeClean.Count * 10;
        sliderList[1].value = gases;

        gameObject.GetComponent<GameController>().population = housesBad.Count * 10 + housesClean.Count * 10;

        sliderList[2].maxValue = gameObject.GetComponent<GameController>().population;
        education = schoolBad.Count * 100 + schoolClean.Count * 100;
        sliderList[2].value = education;

        sliderList[3].maxValue = gameObject.GetComponent<GameController>().population;
        health = hospitalBad.Count * 100 + hospitalClean.Count * 100;
        sliderList[3].value = health;
    }

    public void CheckONUObjectives()
    {
        if(gameObject.GetComponent<GameController>().population > 0)
        {
            if((housesBad.Count + housesClean.Count)*10 >= gameObject.GetComponent<GameController>().population && food >= gameObject.GetComponent<GameController>().population && education >= gameObject.GetComponent<GameController>().population && storesBad.Count + storesClean.Count > 0)
            //tem casa para todos
            {
                onuObjectives[1].SetActive(false);
            }else
            {
                onuObjectives[1].SetActive(true);
            }

            if (food >= gameObject.GetComponent<GameController>().population)
            //tem comida para todos
            {
                onuObjectives[2].SetActive(false);
            }
            else
            {
                onuObjectives[2].SetActive(true);
            }

            if (health >= gameObject.GetComponent<GameController>().population)
            //tem saúde para todos
            {
                onuObjectives[3].SetActive(false);
            }
            else
            {
                onuObjectives[3].SetActive(true);
            }

            if (education >= gameObject.GetComponent<GameController>().population)
            //tem educacao para todos
            {
                onuObjectives[4].SetActive(false);
            }
            else
            {
                onuObjectives[4].SetActive(true);
            }

            if (education >= gameObject.GetComponent<GameController>().population && housesBad.Count + housesClean.Count > 0 && storesBad.Count + storesClean.Count > 0)
            //tem educação, casas e lojas para todos na cidade
            {
                onuObjectives[5].SetActive(false);
            }
            else
            {
                onuObjectives[5].SetActive(true);
            }

            if (housesBad.Count + storesBad.Count + plantationsBad.Count + recyclersBad.Count + schoolBad.Count + hospitalBad.Count + factoryBad.Count + factoryBad.Count <= 0)
            //nao tem quase nenhuma construcao suja
            {
                onuObjectives[6].SetActive(false);
            }
            else
            {
                onuObjectives[6].SetActive(true);
            }

            if (housesBad.Count + storesBad.Count + plantationsBad.Count + recyclersBad.Count + schoolBad.Count + hospitalBad.Count + factoryBad.Count + factoryBad.Count <= 0)
            //nao tem quase nenhuma construcao suja
            {
                onuObjectives[7].SetActive(false);
            }
            else
            {
                onuObjectives[7].SetActive(true);
            }

            if ((storesBad.Count + storesClean.Count)*20 >= GetComponent<GameController>().population && GetComponent<GameController>().money > 0)
            //uma central de loja para cada duas centrais de casa e dinheiro positivo
            {
                onuObjectives[8].SetActive(false);
            }
            else
            {
                onuObjectives[8].SetActive(true);
            }

            if ((storesBad.Count + storesClean.Count) * 20 >= GetComponent<GameController>().population && streetsClean.Count > 0 && housesClean.Count > 0 && storesClean.Count > 0 && plantationsClean.Count > 0 && recyclersClean.Count > 0 && schoolClean.Count > 0 && hospitalClean.Count > 0 && factoryClean.Count > 0)
            //uma central de loja para cada duas centrais de casa e pelo menos uma de cada construcao limpa
            {
                onuObjectives[9].SetActive(false);
            }
            else
            {
                onuObjectives[9].SetActive(true);
            }

            if (education >= gameObject.GetComponent<GameController>().population && (storesBad.Count + storesClean.Count) * 20 >= GetComponent<GameController>().population && (housesBad.Count + housesClean.Count) * 10 >= GetComponent<GameController>().population)
            //tem educacao, moradia e trabalho (uma central de loja para cada duas centrais de casa) para todos
            {
                onuObjectives[10].SetActive(false);
            }
            else
            {
                onuObjectives[10].SetActive(true);
            }

            if (streetsBad.Count + housesBad.Count + storesBad.Count + plantationsBad.Count + recyclersBad.Count + schoolBad.Count + hospitalBad.Count + factoryBad.Count <= 0 && streetsClean.Count > 0 && housesClean.Count > 0 && storesClean.Count > 0 && plantationsClean.Count > 0 && recyclersClean.Count > 0 && schoolClean.Count > 0 && hospitalClean.Count > 0 && factoryClean.Count > 0)
            //nenhuma estrutura suja e pelo menos uma de cada limpa
            {
                onuObjectives[11].SetActive(false);
            }
            else
            {
                onuObjectives[11].SetActive(true);
            }

            if (streetsBad.Count + housesBad.Count + storesBad.Count + plantationsBad.Count + recyclersBad.Count + schoolBad.Count + hospitalBad.Count + factoryBad.Count <= 0 && streetsClean.Count > 0 && housesClean.Count > 0 && storesClean.Count > 0 && plantationsClean.Count > 0 && recyclersClean.Count > 0 && schoolClean.Count > 0 && hospitalClean.Count > 0 && factoryClean.Count > 0)
            //nenhuma estrutura suja e pelo menos uma de cada limpa
            {
                onuObjectives[12].SetActive(false);
            }
            else
            {
                onuObjectives[12].SetActive(true);
            }

            if (streetsBad.Count + housesBad.Count + storesBad.Count + plantationsBad.Count + recyclersBad.Count + schoolBad.Count + hospitalBad.Count + factoryBad.Count <= 0 && streetsClean.Count > 0 && housesClean.Count > 0 && storesClean.Count > 0 && plantationsClean.Count > 0 && recyclersClean.Count > 0 && schoolClean.Count > 0 && hospitalClean.Count > 0 && factoryClean.Count > 0)
            //nenhuma estrutura suja e pelo menos uma de cada limpa
            {
                onuObjectives[13].SetActive(false);
            }
            else
            {
                onuObjectives[13].SetActive(true);
            }

            if (housesBad.Count + storesBad.Count + plantationsBad.Count + recyclersBad.Count + schoolBad.Count + hospitalBad.Count + factoryBad.Count <= 0 && housesClean.Count > 0 && storesClean.Count > 0 && plantationsClean.Count > 0 && recyclersClean.Count > 0 && schoolClean.Count > 0 && hospitalClean.Count > 0 && factoryClean.Count > 0)
            //quase nenhuma estrutura suja e pelo menos uma de cada limpa
            {
                onuObjectives[14].SetActive(false);
            }
            else
            {
                onuObjectives[14].SetActive(true);
            }

            if (treeBad.Count + treeClean.Count > 0 && gases <= sliderList[1].maxValue)
            //pelo menos uma árvore e gases controlados
            {
                onuObjectives[15].SetActive(false);
            }
            else
            {
                onuObjectives[15].SetActive(true);
            }

            if (food >= gameObject.GetComponent<GameController>().population && education >= gameObject.GetComponent<GameController>().population && health >= gameObject.GetComponent<GameController>().population)
            //comida, saúde e educação para todos
            {
                onuObjectives[16].SetActive(false);
            }
            else
            {
                onuObjectives[16].SetActive(true);
            }

            if (!onuObjectives[1].activeSelf && !onuObjectives[2].activeSelf && !onuObjectives[3].activeSelf && !onuObjectives[4].activeSelf && !onuObjectives[5].activeSelf && !onuObjectives[6].activeSelf && !onuObjectives[7].activeSelf && !onuObjectives[8].activeSelf && !onuObjectives[9].activeSelf && !onuObjectives[10].activeSelf && !onuObjectives[11].activeSelf && !onuObjectives[12].activeSelf && !onuObjectives[13].activeSelf && !onuObjectives[14].activeSelf && !onuObjectives[15].activeSelf && !onuObjectives[16].activeSelf)
            //todos os objetivos já foram completados
            {
                canvas.GetComponent<UIManager>().OpenPanel(15);
                onuObjectives[17].SetActive(false);
            }
            else
            {
                onuObjectives[17].SetActive(true);
            }
        }
    }
}
