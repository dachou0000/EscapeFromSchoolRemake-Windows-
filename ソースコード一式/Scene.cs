//using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void TitletoStage1()
    {
        SceneManager.LoadScene("Stage1");   
    }

    public  void EndtoTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
