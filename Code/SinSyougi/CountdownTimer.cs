using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 120f;  // �������ԁi2�� = 120�b�j
    public AudioClip countdownSound; // �J�E���g�_�E�����ɍĐ����鉹

    private TextMeshProUGUI timerText;
    private float currentTime;
    private AudioSource audioSource;

    void Start()
    {
        //�f�o�b�O
        //totalTime=20;
        timerText = GetComponent<TextMeshProUGUI>();
        currentTime = totalTime;

        // AudioSource���擾�܂��͒ǉ�
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // ���ʂ𔼕��ɐݒ�
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
            // 1�b�o�߂��Ƃɉ����Đ�
            PlayCountdownSound();
        }

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            // �������Ԃ��I�������Ƃ��̏�����ǉ�����i�Ⴆ�΃Q�[���I�[�o�[�Ȃǁj

            // �^�C�}�[��0�ɂȂ�����w��̃V�[���Ɉړ�
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
