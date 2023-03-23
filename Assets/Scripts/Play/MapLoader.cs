using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : SaveStructure
{
    public Camera[] cam = new Camera[1];
    public GameObject[] NodePrefab = new GameObject[5];

    public void mapspawn(dataset dataset)
    {
        cam[0] = FindObjectOfType<Camera>();

        float i, j;
        int Xcoor = 0, Ycoor = 0;

        GameObject prevnode = null, node = null;

        for (j = 0.15f; j <= 0.85f; j = j + 0.7f / (dataset.rangey))
        {
            Xcoor = 0;
            for (i = 0.12f; i <= 0.95f; i = i + 0.9f / (dataset.rangex))
            {
                //Debug.Log("index is " + dataset.nodepositions[Xcoor, Ycoor]);

                if (Xcoor != 0)
                {
                    prevnode = node;
                }

                node = Instantiate(NodePrefab[dataset.nodeTypes[Xcoor, Ycoor]], dataset.nodepositions[Xcoor, Ycoor], Quaternion.identity);
                node.tag = dataset.tags[Xcoor, Ycoor];

                MapNode nodescript =  node.GetComponent<MapNode>();
                nodescript.xCoordinate = Xcoor;
                nodescript.yCoordinate = Ycoor;

                if (Xcoor < dataset.rangex)
                    Xcoor++;

            }
            Ycoor++;
        }

        drawLine(dataset.rangex, dataset.rangey, dataset.nodepositions);

    }

    private void drawLine(int x, int y, Vector3[,] coordinates)
    {
        GameObject[] linerenderers = new GameObject[y + 1];
        LineRenderer[] lines = new LineRenderer[y + 1];

        int k, l, j = 0;
        for (k = 0; k < (y + 1); k++)
        {
            linerenderers[k] = new GameObject("lineRenderer");
            linerenderers[k].AddComponent(typeof(LineRenderer));
            lines[k] = linerenderers[k].GetComponent<LineRenderer>();
            lines[k].positionCount = (x);
            lines[k].SetWidth(0.05f, 0.05f);

            for (l = 0; l < (x); l++)
            {
                j++;
                //Debug.Log("coordinates are " + coordinates[l, k]);
                lines[k].SetPosition(l, coordinates[l, k]);
            }
        }

        for (k = 0; k < (x) * (y + 1); k++)
        {
            //Debug.Log("index is " + k);
            //Debug.Log("coordinates are " + coordinates[k]);
        }
        //Debug.Log(j + "times line drawen");
    }
}
