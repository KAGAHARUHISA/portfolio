using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDrop : MonoBehaviour
{
    //  資源ゴミオブジェクトや可燃ゴミオブジェクトの物理を格納
    [SerializeField] Rigidbody2D _rb;

    //  ScriptableObjectそのものを格納
    [SerializeField] private GarbageDropPower _garbageDropPower;

    // Start is called before the first frame update
    void Start()
    {
        //  ScriptableObject内の落下させる力を格納
        float dropPower = _garbageDropPower._dropPower;

        _rb.AddForce(Vector2.down * dropPower);   
    }
}
