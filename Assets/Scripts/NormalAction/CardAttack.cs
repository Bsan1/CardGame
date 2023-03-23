using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAttack: MonoBehaviour
{
    private string Name = "blade";
    private int EnergyCost = 1;
    private int Damage = 4;
    private Vector3 scale;

    private void Awake()
    {
        scale = this.transform.localScale;
    }

    private void OnMouseEnter()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 2);
    }

    private void OnMouseOver()
    {
        float scalex = this.transform.localScale.x;
        float scaley = this.transform.localScale.y;
        float newScalex = Mathf.Lerp(scalex, Mathf.Log(50, scalex), Time.deltaTime);
        float newScaley = Mathf.Lerp(scaley, 1.8f * Mathf.Log(100, scaley), Time.deltaTime);
        this.transform.localScale = new Vector3(newScalex, newScaley, 1);
    }

    private void OnMouseExit()
    {
        this.transform.localScale = new Vector3(scale.x, scale.y, 1);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 1);
    }
}
