using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_stage1 : MonoBehaviour
{
    public void change_button()
    {
        SceneManager.LoadScene("title_scene");
    }
}