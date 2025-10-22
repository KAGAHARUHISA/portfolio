using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトが何か判定する
        // ここではタグを使って判定していますが、他の方法もあります

        if (other.CompareTag("StageFloor"))
        {
          
            // 衝突したオブジェクトがプレイヤーや敵、障害物などである場合、Cannon_Ammoオブジェクトを破棄する
            Destroy(gameObject);

        }

        if (other.CompareTag("PlayerCharacter"))
        {
            SceneManager.LoadScene("GameOver_Scene");
        }


    }
}
