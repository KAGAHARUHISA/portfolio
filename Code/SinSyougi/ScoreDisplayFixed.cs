using UnityEngine;
using TMPro;

public class ScoreDisplayFixed : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // TextMeshProUGUIを保持する変数

    void Start()
    {
        // PlayerPrefsからポイントを取得
        int playerScore = PlayerPrefs.GetInt("Points", 0);

        // TextMeshProUGUIが設定されていれば、スコアを表示
        if (scoreText != null)
        {
            scoreText.text = playerScore.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text is not assigned to the script. Assign a TextMeshProUGUI component in the inspector.");
        }
    }
}