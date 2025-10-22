using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip awaySound; // プレイヤーが離れた時の音
    private AudioSource audioSource;
    private Vector3 lastPosition; // 直前の位置

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPosition = transform.position;
    }

    void Update()
    {
        CheckMovementAndPlaySound();
    }

    void CheckMovementAndPlaySound()
    {
        if (awaySound != null && audioSource != null)
        {
            // 直前の位置と現在の位置が一致しない場合、音を再生
            if (transform.position != lastPosition)
            {
                audioSource.PlayOneShot(awaySound);
            }

            // 現在の位置を直前の位置に更新
            lastPosition = transform.position;
        }
    }
}
