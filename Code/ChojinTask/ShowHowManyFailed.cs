using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHowManyFailed : MonoBehaviour
{
    //  ���s�����񐔂𔽉f������X�N���v�g

    TextMeshProUGUI _showHowManyFailed;
    void Start()
    {
        _showHowManyFailed = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _showHowManyFailed.text = AllMiniGameFailedManager.FAILED_TIME + "�񎸔s";
    }
}
