using UnityEngine;
using TMPro;

public class ResultScene : MonoBehaviour
{
    public TMP_Text pointsText;

    private void Start()
    {
        int pointsInResultScene = PlayerPrefs.GetInt("Points", 0);

        if (pointsText != null)
        {
            pointsText.text = "Points: " + pointsInResultScene.ToString();
        }

        PlayerPrefs.DeleteKey("Points"); // PlayerPrefs をクリアする（次回プレイのため）
    }
}
