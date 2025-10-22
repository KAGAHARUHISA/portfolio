using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 120f;  // 制限時間（2分 = 120秒）
    public AudioClip countdownSound; // カウントダウン時に再生する音

    private TextMeshProUGUI timerText;
    private float currentTime;
    private AudioSource audioSource;

    void Start()
    {
        //デバッグ
        //totalTime=20;
        timerText = GetComponent<TextMeshProUGUI>();
        currentTime = totalTime;

        // AudioSourceを取得または追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 音量を半分に設定
        audioSource.volume = 0.35f;
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        float previousTime = currentTime;
        currentTime -= Time.deltaTime;

        if (Mathf.FloorToInt(previousTime) != Mathf.FloorToInt(currentTime))
        {
            // 1秒経過ごとに音を再生
            PlayCountdownSound();
        }

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            // 制限時間が終了したときの処理を追加する（例えばゲームオーバーなど）

            // タイマーが0になったら指定のシーンに移動
            SceneManager.LoadScene("Result");
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PlayCountdownSound()
    {
        if (countdownSound != null)
        {
            audioSource.PlayOneShot(countdownSound);
        }
    }
}
