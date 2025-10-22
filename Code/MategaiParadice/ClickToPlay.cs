using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using UnityEngine.SceneManagement;

public class ClickToPlay : MonoBehaviour
{
    public void MouseClick_Hard()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

    public void MouseClick_Easy()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("EasyPlayScene");
        }
    }


}
