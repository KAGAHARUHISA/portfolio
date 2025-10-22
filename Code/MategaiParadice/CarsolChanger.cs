using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsolChanger : MonoBehaviour
{

    public Texture2D handCursor;
    public Texture2D fist;

    void Start()
    {
        Cursor.SetCursor(handCursor, new Vector2(handCursor.width / 2, handCursor.height / 2), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(fist, new Vector2(fist.width / 2, fist.height / 2), CursorMode.Auto);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(handCursor, new Vector2(handCursor.width / 2, handCursor.height / 2), CursorMode.Auto);
        }
    }
}
