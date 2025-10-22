using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab; // 発射する弾丸のプレハブ
    public float fireForce = 10f;       // 発射する力
    public float fireInterval = 2f;     // 発射間隔（秒）

    private float timer;                // 発射間隔のタイマー

    void Start()
    {
        timer = fireInterval;           // タイマーの初期化
    }

    void Update()
    {
        // タイマーを更新
        timer -= Time.deltaTime;

        // タイマーが0以下になったら発射する
        if (timer <= 0)
        {
            Fire();
            // タイマーを再設定する
            timer = fireInterval;
        }
    }

    // 弾丸を発射するメソッド
    void Fire()
    {
        // 弾丸のインスタンスを生成し、位置と回転を大砲に合わせる
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        // Rigidbodyを取得し、力を加えて左方向に発射する
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.left * fireForce, ForceMode2D.Impulse);
        }
    }
}
