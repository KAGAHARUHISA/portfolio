using UnityEngine;

public class EscapeToDesktop : MonoBehaviour
{
    void Update()
    {
        // ESCキーが押されたかどうかをチェック
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ゲームを終了する（ウィンドウズ画面に戻る）
            Application.Quit();
        }
    }
}
