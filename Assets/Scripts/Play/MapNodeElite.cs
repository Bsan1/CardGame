using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNodeElite : Trigger
{
    public bool isClickable = false;

    void OnMouseOver()
    {
        if (this.CompareTag("Reachable") == true)
        {
            isClickable = true;
        }

        if (Input.GetMouseButtonDown(0) && isClickable == true)
        {
            createColldider();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager manager = FindObjectOfType<GameManager>();
        Debug.Log("collider triggered " + manager.storage.rangex);

        if (manager.storage.rangex != xCoordinate)
        {
            manager.storage.tags[xCoordinate, yCoordinate] = "Reachable";
        }

        SceneManager.LoadScene(4);
    }
}
