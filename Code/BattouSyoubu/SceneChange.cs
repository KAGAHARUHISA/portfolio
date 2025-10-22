using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string _nextSceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }
   
}
