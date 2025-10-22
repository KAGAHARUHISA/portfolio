using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class WaveStart : MonoBehaviour
{
    [SerializeField] private VideoPlayer _videoPlayer;

    [SerializeField] private Vector3 _setWavePos;

    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _videoPlayer.targetTexture.Release();
        StartCoroutine(Wave());
    }

    IEnumerator Wave()
    {
        this._videoPlayer.Stop();
        yield return new WaitForSeconds(52);
        this._videoPlayer.Play();
        yield return new WaitForSeconds(1f);
        _rectTransform.position = _setWavePos;
        Debug.Log("aaaaaaaaaaaaaaaaaaaaa");

    }

}
