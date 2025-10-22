using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CursorChanger : MonoBehaviour
{

    //  変わるカーソルのデザイン
    [SerializeField] private Texture2D _cursorTexture;

    //  ホットスポットの指定
    [SerializeField] private Vector2 hotSpot = Vector2.zero;
    void OnMouseEnter()
    {
        Cursor.SetCursor(_cursorTexture, hotSpot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        // nullにするとデフォルトのテクスチャに戻る
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}