using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDrop : MonoBehaviour
{
    //  �����S�~�I�u�W�F�N�g��R�S�~�I�u�W�F�N�g�̕������i�[
    [SerializeField] Rigidbody2D _rb;

    //  ScriptableObject���̂��̂��i�[
    [SerializeField] private GarbageDropPower _garbageDropPower;

    // Start is called before the first frame update
    void Start()
    {
        //  ScriptableObject���̗���������͂��i�[
        float dropPower = _garbageDropPower._dropPower;

        _rb.AddForce(Vector2.down * dropPower);   
    }
}
