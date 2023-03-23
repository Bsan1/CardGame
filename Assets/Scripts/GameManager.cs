using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SaveStructure
{
    private bool IsNodesCreated = false;
    private bool IsLevelFinished = false;

    public dataset storage;

    private void Awake()
    {

        DontDestroyOnLoad(this);
        CreateLevel();
        IsNodesCreated = true;
        SceneManager.activeSceneChanged += ChangedActiveScene;
        
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        Debug.Log("active scene changed" + next.buildIndex);
        if (next.buildIndex == 1)
        {
            Debug.Log("loaded scene is 2");
            if (IsNodesCreated == true)
            {
                Loadlevel();
            }
            else if (IsNodesCreated == true && IsLevelFinished == true)
            {
                CreateLevel();
            }
        }
    }


    public void CreateLevel()
    {
        GameObject spawner = GameObject.Find("MapStarter");
        CreateRandomObjectData datascript = (spawner.GetComponent<CreateRandomObjectData>());
        MapLoader loaderscript = (spawner.GetComponent<MapLoader>());
        storage = datascript.CreateNodes();
        loaderscript.mapspawn(storage);

    }

    public void Loadlevel()
    {
        GameObject spawner = GameObject.Find("MapStarter");
        MapLoader loaderscript = (spawner.GetComponent<MapLoader>());
        int y = storage.rangey;
        for( ; y != -1 ; y--)
        {
            storage.tags[0,y] = "Unreachable";
        }
        loaderscript.mapspawn(storage);
    }
}
