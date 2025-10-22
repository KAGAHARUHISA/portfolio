using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_to_Play : MonoBehaviour
{

    public GameObject EasyMode;
    public GameObject HardMode;
    public GameObject Rank;
    public GameObject Back;

    private void Start()
    {
        EasyMode.SetActive(false);
        HardMode.SetActive(false);
    }

    public void StartButton()
    {
        EasyMode.SetActive(true);
        HardMode.SetActive(true);
        Rank.SetActive(false);
        Back.SetActive(true);
        this.gameObject.SetActive(false);
    }
}