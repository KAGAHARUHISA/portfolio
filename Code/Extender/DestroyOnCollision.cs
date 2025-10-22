using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトがタグ「PlayerCharacter」を持っているかチェック
        if (collision.gameObject.CompareTag("PlayerCharacter"))
        {
            // Game Overシーンに遷移
            SceneManager.LoadScene("GameOver_Scene");
        }
    }
}
