using UnityEngine;

public class FireBar : MonoBehaviour
{
    public int numberOfBalls = 10;          // ボールの数（ファイヤーバーの長さ）
    public float rotationSpeed = 90.0f;     // 回転速度（度/秒）
    public float moveDistance = 1.0f;       // 上下に振動する距離
    public float moveSpeed = 1.0f;          // 振動速度
    public float scaleIncreaseAmount = 1.0f; // Y方向に増加するスケールの量
    public GameObject ballPrefab;           // ボールのプレハブ

    private GameObject[] balls;             // ボールの配列
    private Vector3 initialScale;           // 初期スケール
    private Vector3 initialPosition;        // 初期位置
    private float startTime;                // 振動開始時間

    void Start()
    {
        initialScale = transform.localScale;  // 初期スケールを保存
        initialPosition = transform.position; // 初期位置を保存
        startTime = Time.time;                // 振動開始時間を記録

        // ボールの配列を作成
        balls = new GameObject[numberOfBalls];

        // ボールを生成して配置する
        for (int i = 0; i < numberOfBalls; i++)
        {
            float angle = i * (360.0f / numberOfBalls);
            Vector3 offset = Quaternion.Euler(0, 0, angle) * Vector3.right * 0.5f;
            GameObject ball = Instantiate(ballPrefab, transform.position + offset, Quaternion.identity, transform);
            balls[i] = ball;
        }
    }

    void Update()
    {
        // 回転運動を行う（Z軸周り）
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // 上下の振動を行う
        float elapsedTime = Time.time - startTime;
        float yPos = Mathf.Sin(elapsedTime * moveSpeed) * moveDistance;
        transform.position = initialPosition + Vector3.up * yPos;

        // Y方向にスケールを増加する
        float scaleFactor = 1.0f + scaleIncreaseAmount;
        Vector3 newScale = initialScale;
        newScale.y *= scaleFactor;
        transform.localScale = newScale;
    }

    void OnValidate()
    {
        // インスペクターウィンドウで値が変更されたときに、初期スケールを更新
        initialScale = transform.localScale;
    }
}
