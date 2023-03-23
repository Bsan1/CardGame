using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : CardAttackData
{
    public int[] CardsTypesbyId = new int[99];
    private int cardNumber = 8;
    public GameObject[] cards = new GameObject[5];
    public Camera[] cam = new Camera[1];

    private void Awake()
    {
        cam[0] = FindObjectOfType<Camera>();
        float i;

        //for (j = 0.15f; j <= 0.85f; j = j + 0.7f / (cardNumber))
        //{
            for (i = 0.15f; i <= 0.85f; i = i + (0.7f / (cardNumber)))
            {
                Vector3 position = cam[0].ViewportToWorldPoint(new Vector3( i, 0.25f, cam[0].nearClipPlane + 1f));

                CardCreate(0, position);

            }
        //}
    }

    private void CardCreate(int index, Vector3 position)
    {
        Instantiate(cards[index], position, Quaternion.identity);
    }
}
