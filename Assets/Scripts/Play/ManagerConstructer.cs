using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerConstructer : MonoBehaviour
{
    public GameObject[] gameManager = new GameObject[1];
    public static bool gamemanegercreated = false;

    private void Start()
    {
        if (gamemanegercreated == false)
        {
            Instantiate(gameManager[0], this.transform.localPosition, Quaternion.identity);
            gamemanegercreated = true;
        }
        this.enabled = false;
    }
}
