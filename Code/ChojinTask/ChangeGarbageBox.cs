using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGarbageBox : MonoBehaviour
{
    [SerializeField] GameObject _combustibleGarbageBox;
    [SerializeField] GameObject _recyclableGarbageBox;

    //  �R���݂Ǝ������݂̃S�~���̈ʒu���t�]
    public void ChangeGarbegeBoxPosition()
    {
        Vector3 combustibleGarbageBoxPostion = _combustibleGarbageBox.transform.position;
        Vector3 recyclableGarbageBoxPostion = _recyclableGarbageBox.transform.position;

        _recyclableGarbageBox.transform.position = combustibleGarbageBoxPostion;
        _combustibleGarbageBox.transform.position = recyclableGarbageBoxPostion;
    }

}
