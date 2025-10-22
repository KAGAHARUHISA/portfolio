using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    [SerializeField] string _nextSceneName;

    [SerializeField] float _fadeTime;

    [SerializeField] GameObject _fadePanel;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_nextSceneName);
    }

    public void FadeInChangeScene()
    {
        StartCoroutine(FadeInChangeSceneCoroutine());
    }

    IEnumerator FadeInChangeSceneCoroutine()
    {
        FadeInFadeOut fadeInFadeOut = _fadePanel.GetComponent<FadeInFadeOut>();
        fadeInFadeOut._in = true;
        yield return new WaitForSeconds(_fadeTime);
        SceneManager.LoadScene(_nextSceneName);
    }

    public void FadeOutChangeScene()
    {
        StartCoroutine(FadeOutChangeSceneCoroutine());
    }

    IEnumerator FadeOutChangeSceneCoroutine()
    {
        FadeInFadeOut fadeInFadeOut = _fadePanel.GetComponent<FadeInFadeOut>();
        fadeInFadeOut._out = true;
        yield return new WaitForSeconds(_fadeTime);
        SceneManager.LoadScene(_nextSceneName);
    }

}
