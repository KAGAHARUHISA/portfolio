using UnityEngine;

public class BalloonObject : MonoBehaviour
{
    public float maxXScale = 2.0f;    // 膨らむ最大のXスケール
    public float expandTime = 5.0f;   // 膨らむ時間

    private float initialXScale;      // 初期のXスケール
    private float startTime;          // 膨らみ開始時間

    void Start()
    {
        initialXScale = transform.localScale.x; // オブジェクトの初期Xスケールを保存
        startTime = Time.time;                  // 膨らみ開始時間を記録
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime; // 経過時間を計算
        float progress = elapsedTime / expandTime; // 膨らむ進捗率

        if (elapsedTime < expandTime)
        {
            // 膨らむ進捗率に応じてXスケールを変更する
            float scaleX = Mathf.Lerp(initialXScale, maxXScale, progress);
            Vector3 newScale = transform.localScale;
            newScale.x = scaleX;
            transform.localScale = newScale;
        }
        else
        {
            // 膨らむ時間が経過したら、膨らむ操作を停止する
            Vector3 finalScale = transform.localScale;
            finalScale.x = maxXScale;
            transform.localScale = finalScale;
        }
    }
}
