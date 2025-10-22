using UnityEngine;
using TMPro;

public class ScoreDisplayFixed : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // TextMeshProUGUI��ێ�����ϐ�

    void Start()
    {
        // PlayerPrefs����|�C���g���擾
        int playerScore = PlayerPrefs.GetInt("Points", 0);

        // TextMeshProUGUI���ݒ肳��Ă���΁A�X�R�A��\��
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