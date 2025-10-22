using UnityEngine;

public class EscapeHandler : MonoBehaviour
{
    // Startメソッドを追加
    void Start()
    {
        Debug.Log("Script is attached to: " + gameObject.name);
    }

    void Update()
    {
        // ESCキーが押されたら
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // アプリケーションを終了する
            Application.Quit();

            // もしエディタ内で実行している場合、エディタの再生を停止する
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
