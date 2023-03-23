using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStructure : MonoBehaviour
{
    public struct dataset
    {
        public int rangex, rangey;
        public float rndX, rndY;
        public Vector3[,] nodepositions;
        public int[,] nodeTypes;
        public string[,] tags;
    }
}
