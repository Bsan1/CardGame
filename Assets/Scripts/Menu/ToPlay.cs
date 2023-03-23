using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPlay : MonoBehaviour
{
    public string sceneName = "Play";
    public bool isnextscene = true;

    // Start is called before the first frame update
    void awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("loading play");
    }
}
