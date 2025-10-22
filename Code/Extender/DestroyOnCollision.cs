using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���^�O�uPlayerCharacter�v�������Ă��邩�`�F�b�N
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            // Game Over�V�[���ɑJ��
            SceneManager.LoadScene("GameOver_Scene");
        }
    }
}
