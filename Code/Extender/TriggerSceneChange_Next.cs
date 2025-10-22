using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChange_Next : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトがPlayerCharacterタグを持つ場合
        if (other.CompareTag("PlayerCharacter"))
        {
            // ClearSceneにシーンを遷移する
            SceneManager.LoadScene("Stage2");
        }
    }
}
