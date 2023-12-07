using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionSpace : MonoBehaviour
{
    public GameObject myConstruction;
    GameObject gameController;
    public Vector3 offset;
    float myPrice;
    int myConstructionList;
    int myIndex;
    public int xpos, ypos;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if (myConstruction != null)
            {
                if (myConstruction.CompareTag("Transparent"))
                {
                    Destroy(myConstruction);
                }
            }
        }
    }

    void OnMouseOver()
    {
        if (myConstruction != null)
        {
            return;
        }
        if(gameController.GetComponent<ConstructionManager>().constructionMode)
        {
            switch (gameController.GetComponent<ConstructionManager>().constructionType)
            {
                case "streetBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[0], transform.position + offset, Quaternion.identity);
                    break;

                case "plantationBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[1], transform.position + offset, Quaternion.identity);
                    break;

                case "plantationClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[2], transform.position + offset, Quaternion.identity);
                    break;

                case "streetClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[3], transform.position + offset, Quaternion.identity);
                    break;

                case "housesBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[4], transform.position + offset, Quaternion.identity);
                    break;

                case "housesClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[5], transform.position + offset, Quaternion.identity);
                    break;

                case "recyclersBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[6], transform.position + offset, Quaternion.identity);
                    break;

                case "recyclersClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[7], transform.position + offset, Quaternion.identity);
                    break;

                case "storesBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[8], transform.position + offset, Quaternion.identity);
                    break;

                case "storesClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[9], transform.position + offset, Quaternion.identity);
                    break;

                case "schoolBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[10], transform.position + offset, Quaternion.identity);
                    break;

                case "schoolClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[11], transform.position + offset, Quaternion.identity);
                    break;

                case "hospitalBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[12], transform.position + offset, Quaternion.identity);
                    break;

                case "hospitalClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[13], transform.position + offset, Quaternion.identity);
                    break;

                case "treeBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[14], transform.position + offset, Quaternion.identity);
                    break;

                case "treeClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[15], transform.position + offset, Quaternion.identity);
                    break;

                case "factoryBad":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[16], transform.position + offset, Quaternion.identity);
                    break;

                case "factoryClean":
                    myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().trasnparentStructures[17], transform.position + offset, Quaternion.identity);
                    break;

                default:
                    break;
            }
        }
    }

    void OnMouseDown()
    {
        if (gameController.GetComponent<ConstructionManager>().demolitionMode)
        {
            if(gameController.GetComponent<ObjectivesManager>().recyclersClean.Count > 0)
            {
                gameController.GetComponent<GameController>().ChangeMoney(+myPrice);
            }
            else if (gameController.GetComponent<ObjectivesManager>().recyclersBad.Count > 0)
            {
                gameController.GetComponent<GameController>().ChangeMoney(+myPrice * 0.8f);
            }

            Destroy(myConstruction);
            switch (myConstructionList)
            {
                case 0:
                    gameController.GetComponent<ObjectivesManager>().streetsBad.Remove(myConstruction.gameObject);
                    break;

                case 1:
                    gameController.GetComponent<ObjectivesManager>().plantationsBad.Remove(myConstruction.gameObject);
                    break;

                case 2:
                    gameController.GetComponent<ObjectivesManager>().plantationsClean.Remove(myConstruction.gameObject);
                    break;

                case 3:
                    gameController.GetComponent<ObjectivesManager>().streetsBad.Remove(myConstruction.gameObject);
                    break;

                case 4:
                    gameController.GetComponent<ObjectivesManager>().housesBad.Remove(myConstruction.gameObject);
                    break;

                case 5:
                    gameController.GetComponent<ObjectivesManager>().housesClean.Remove(myConstruction.gameObject);
                    break;

                case 6:
                    gameController.GetComponent<ObjectivesManager>().recyclersBad.Remove(myConstruction.gameObject);
                    break;

                case 7:
                    gameController.GetComponent<ObjectivesManager>().recyclersClean.Remove(myConstruction.gameObject);
                    break;

                case 8:
                    gameController.GetComponent<ObjectivesManager>().storesBad.Remove(myConstruction.gameObject);
                    break;

                case 9:
                    gameController.GetComponent<ObjectivesManager>().storesClean.Remove(myConstruction.gameObject);
                    break;

                case 10:
                    gameController.GetComponent<ObjectivesManager>().schoolBad.Remove(myConstruction.gameObject);
                    break;

                case 11:
                    gameController.GetComponent<ObjectivesManager>().schoolClean.Remove(myConstruction.gameObject);
                    break;

                case 12:
                    gameController.GetComponent<ObjectivesManager>().hospitalBad.Remove(myConstruction.gameObject);
                    break;

                case 13:
                    gameController.GetComponent<ObjectivesManager>().hospitalClean.Remove(myConstruction.gameObject);
                    break;

                case 14:
                    gameController.GetComponent<ObjectivesManager>().treeBad.Remove(myConstruction.gameObject);
                    break;

                case 15:
                    gameController.GetComponent<ObjectivesManager>().treeClean.Remove(myConstruction.gameObject);
                    break;

                case 16:
                    gameController.GetComponent<ObjectivesManager>().factoryBad.Remove(myConstruction.gameObject);
                    break;

                case 17:
                    gameController.GetComponent<ObjectivesManager>().factoryClean.Remove(myConstruction.gameObject);
                    break;

                default:
                    break;
            }
            myConstruction = null;
        }

        if (myConstruction != null)
        {
            if (!myConstruction.CompareTag("Transparent"))
                return;
        }
        if (gameController.GetComponent<ConstructionManager>().constructionMode)
        {
            switch (gameController.GetComponent<ConstructionManager>().constructionType)
            {
                case "streetBad":
                    myIndex = 0;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().streetsBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;


                case "plantationBad":
                    myIndex = 1;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().plantationsBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "plantationClean":
                    myIndex = 2;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().plantationsClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "streetClean":
                    myIndex = 3;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().streetsClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "housesBad":
                    myIndex = 4;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().housesBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                        myConstruction.GetComponent<CarSpawn>().xpos = xpos;
                        myConstruction.GetComponent<CarSpawn>().ypos = ypos;
                    }
                    break;

                case "housesClean":
                    myIndex = 5;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().housesClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                        myConstruction.GetComponent<CarSpawn>().xpos = xpos;
                        myConstruction.GetComponent<CarSpawn>().ypos = ypos;
                    }
                    break;

                case "recyclersBad":
                    myIndex = 6;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().recyclersBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                        myConstruction.GetComponent<CarSpawn>().xpos = xpos;
                        myConstruction.GetComponent<CarSpawn>().ypos = ypos;
                    }
                    break;

                case "recyclersClean":
                    myIndex = 7;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().recyclersClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                        myConstruction.GetComponent<CarSpawn>().xpos = xpos;
                        myConstruction.GetComponent<CarSpawn>().ypos = ypos;
                    }
                    break;

                case "storesBad":
                    myIndex = 8;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().storesBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "storesClean":
                    myIndex = 9;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().storesClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "schoolBad":
                    myIndex = 10;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().schoolBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "schoolClean":
                    myIndex = 11;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().schoolClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "hospitalBad":
                    myIndex = 12;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().hospitalBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                        myConstruction.GetComponent<CarSpawn>().xpos = xpos;
                        myConstruction.GetComponent<CarSpawn>().ypos = ypos;
                    }
                    break;

                case "hospitalClean":
                    myIndex = 13;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().hospitalClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                        myConstruction.GetComponent<CarSpawn>().xpos = xpos;
                        myConstruction.GetComponent<CarSpawn>().ypos = ypos;
                    }
                    break;

                case "treeBad":
                    myIndex = 14;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().treeBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "treeClean":
                    myIndex = 15;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().treeClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "factoryBad":
                    myIndex = 16;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().factoryBad.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                case "factoryClean":
                    myIndex = 17;
                    if (gameController.GetComponent<GameController>().money >= gameController.GetComponent<PriceController>().prices[myIndex])
                    {
                        Destroy(myConstruction);
                        myConstruction = Instantiate(gameController.GetComponent<ConstructionManager>().normalStructures[myIndex], transform.position + offset, Quaternion.identity);
                        gameController.GetComponent<GameController>().ChangeMoney(-gameController.GetComponent<PriceController>().prices[myIndex]);
                        gameController.GetComponent<ObjectivesManager>().factoryClean.Add(myConstruction);
                        myPrice = gameController.GetComponent<PriceController>().prices[myIndex];
                        myConstructionList = myIndex;
                    }
                    break;

                default:
                    break;
            }
            gameController.GetComponent<ObjectivesManager>().CheckObjectives();
        }
    }

    void OnMouseExit()
    {
        if (myConstruction != null)
        {
            if (myConstruction.CompareTag("Transparent"))
            {
                Destroy(myConstruction);
            }
        }
    }
}
