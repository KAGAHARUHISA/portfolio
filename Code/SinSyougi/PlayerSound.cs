using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip awaySound; // �v���C���[�����ꂽ���̉�
    private AudioSource audioSource;
    private Vector3 lastPosition; // ���O�̈ʒu

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
            // ���O�̈ʒu�ƌ��݂̈ʒu����v���Ȃ��ꍇ�A�����Đ�
            if (transform.position != lastPosition)
            {
                audioSource.PlayOneShot(awaySound);
            }

            // ���݂̈ʒu�𒼑O�̈ʒu�ɍX�V
            lastPosition = transform.position;
        }
    }
}
