using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    public float _speed = 0.02f;        //�t�F�[�h����X�s�[�h
    float _red, _green, _blue, _alfa;

    public bool _out = false;
    public bool _in = false;

    Image fadeImage;                //�p�l��

    void Start()
    {
        fadeImage = GetComponent<Image>();
        _red = fadeImage.color.r;
        _green = fadeImage.color.g;
        _blue = fadeImage.color.b;
        _alfa = fadeImage.color.a;
    }

    void Update()
    {
        if (_in)
        {
            FadeIn();
        }

        if (_out)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        _alfa -= _speed * Time.deltaTime;
        Alpha();
        if (_alfa <= 0)
        {
            fadeImage.enabled = false;
            _in = false;
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        _alfa += _speed * Time.deltaTime;
        Alpha();
        if (_alfa >= 1)
        {
            _out = false;
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(_red, _green, _blue, _alfa);
    }
}
