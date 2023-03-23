using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomObjectData : SaveStructure
{
    public Camera[] cam = new Camera[1];
    public GameObject[] NodePrefab = new GameObject[5];

    public dataset CreateNodes()
    {
        cam[0] = FindObjectOfType<Camera>();
        Vector2 ReachTagger = cam[0].ViewportToWorldPoint(new Vector3(0.21f, 0, cam[0].nearClipPlane));

        dataset toStore = new dataset();

        toStore.rangex = Random.Range(6, 8);
        toStore.rangey = Random.Range(2, 4);
        toStore.rndX = Random.Range(0, 0.06f);
        toStore.rndY = Random.Range(0, 0.04f);

        toStore.nodepositions = new Vector3[(toStore.rangex), (toStore.rangey + 1)];
        toStore.nodeTypes = new int[toStore.rangex + 1, toStore.rangey + 1];
        toStore.tags = new string[toStore.rangex + 1, toStore.rangey + 1];

        float i, j;
        int Xcoor = 0, Ycoor = 0;

        for (j = 0.15f; j <= 0.85f; j = j + 0.7f / (toStore.rangey))
        {
            Xcoor = 0;
            for (i = 0.12f; i <= 0.95f; i = i + 0.9f / (toStore.rangex))
            {
                toStore.nodepositions[Xcoor, Ycoor] = cam[0].ViewportToWorldPoint(new Vector3(Random.Range(i - toStore.rndX, i + toStore.rndX), Random.Range(j - toStore.rndY, j + toStore.rndY), cam[0].nearClipPlane + 1f));
                Debug.Log("Xcoor is " + Xcoor);
                Debug.Log("Ycoor is " + Ycoor);
                if (Xcoor + 1 == toStore.rangex)
                    toStore.nodeTypes[Xcoor, Ycoor] = 4;
                else if (Xcoor == 0)
                    toStore.nodeTypes[Xcoor, Ycoor] = 0;
                else
                    toStore.nodeTypes[Xcoor,Ycoor] = randomiseNode(Xcoor, toStore.nodeTypes[Xcoor, Ycoor], Ycoor);


                if (toStore.nodepositions[Xcoor, Ycoor].x <= ReachTagger.x)
                {
                Debug.Log("chosen type is" + toStore.nodeTypes[Xcoor, Ycoor]);
                    toStore.tags[Xcoor, Ycoor] = "Reachable";
                }
                else
                {
                    toStore.tags[Xcoor, Ycoor] = "Unreachable";
                }


                if (Xcoor < toStore.rangex)
                    Xcoor++;

            }
            Ycoor++;
        }

        return toStore;
    }

    private int randomiseNode(int column, int prevnodetype, int row)
    {
        int rndnumber = Random.Range(0, 15);
        int ChosenNodeType = 0;

            switch (rndnumber)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    ChosenNodeType = 0;
                    break;
                case 7:
                case 8:
                case 9:
                case 13:
                    if (prevnodetype != 1)
                        ChosenNodeType = 1;
                    break;
                case 11:
                case 10:
                case 12:
                    if (prevnodetype != 2)
                        ChosenNodeType = 2;
                    break;
                case 14:
                case 15:
                    if (prevnodetype != 3)
                        ChosenNodeType = 3;
                    break;
                default:
                    ChosenNodeType = 0;
                    break;
            }
        

        return ChosenNodeType;
    }
}
