using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Camera cam = new Camera();
    public GameObject newobject;
    public int xCoordinate , yCoordinate;

    public void createColldider()
    {
        //newcollider.isTrigger = true;
        Vector2 vector = new Vector2(this.transform.localPosition.x + 3f, this.transform.localPosition.y);
        Instantiate(newobject,vector,Quaternion.identity);
        newobject.transform.localPosition = vector;
    }
}
