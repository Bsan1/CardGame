using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNode: Trigger
{
    public bool isClickable = false;

    void OnMouseOver()
    {
        GameManager manager = FindObjectOfType<GameManager>();

        if (this.CompareTag("Reachable") == true)
        {
            isClickable = true;
        }

        if (Input.GetMouseButtonDown(0) && isClickable == true)
        {
            if (manager.storage.rangex != xCoordinate + 1)
                manager.storage.tags[xCoordinate + 1, yCoordinate] = "Reachable";

                loadNewScene(manager);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager manager = FindObjectOfType<GameManager>();
        Debug.Log("collider triggered " + manager.storage.rangex);

        if(manager.storage.rangex != xCoordinate + 1)
        {
            manager.storage.tags[xCoordinate,yCoordinate] = "Reachable";
        }
    }

    void loadNewScene(GameManager manager)
    {
        if(manager.storage.nodeTypes[xCoordinate,yCoordinate] == 0)
            SceneManager.LoadScene(3);
        else if (manager.storage.nodeTypes[xCoordinate, yCoordinate] == 1)
            SceneManager.LoadScene(4);
        else if (manager.storage.nodeTypes[xCoordinate, yCoordinate] == 2)
            SceneManager.LoadScene(5);
        else if (manager.storage.nodeTypes[xCoordinate, yCoordinate] == 3)
            SceneManager.LoadScene(6);
        else if(manager.storage.nodeTypes[xCoordinate, yCoordinate] == 4)
            SceneManager.LoadScene(7);
    }
}
