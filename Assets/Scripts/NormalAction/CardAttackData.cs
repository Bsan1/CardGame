using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct data
{
    public int CardType;
    public string name;
    public int energycost;
    public int activeNumber;
}

[System.Serializable]
public class TopClass
{
    public List<data> cardDatas = new List<data>();
}

public class CardAttackData : MonoBehaviour
{


    public TopClass savingdata = new TopClass();
    public   TopClass data = new TopClass();
    public    data[] card = new data[99];

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveToJson();
        }
    }

    public void SaveToJson()
    {
        for (int i = 0; i < 50; i++)
        {
            card[i].CardType = 1;
            card[i].energycost = 1;
            card[i].activeNumber = 5;
            card[i].name = "slash";

            data.cardDatas.Add(card[i]);

        }


        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        System.IO.File.WriteAllText("C:/Users/ASUS/Documents/UnityProjects/card game/test/data.json", json);
        //Debug.Log(Application.persistentDataPath + "/test/data.json");
                
    }

    public void GetFromJson()
    {
        


    }
}
