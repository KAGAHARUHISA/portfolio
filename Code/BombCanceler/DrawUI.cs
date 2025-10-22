using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawUI : MonoBehaviour
{
    public GameObject _firstText;
    public GameObject _drawText;
    public GameObject FadeOutCover;
    public GameObject Title;
    public GameObject ReStart;
    private Animator m_Animator = null;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FirstTextView());
        StartCoroutine(DrawTextView());
        StartCoroutine(ExplodeView());
        StartCoroutine(FadeOutView());
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            SceneManager.LoadScene("MainScene_KAGA");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            SceneManager.LoadScene("TitleSuzuki");
        }
    }

    IEnumerator FirstTextView()
    {
        yield return new WaitForSeconds(1.5f);
        _firstText.SetActive(true);
    }

    IEnumerator DrawTextView()
    {
        yield return new WaitForSeconds(2.5f);
        _drawText.SetActive(true);
    }

    IEnumerator ExplodeView()
    {
        yield return new WaitForSeconds(3.5f);
        audioSource.Play();
    }

    IEnumerator FadeOutView()
    {
        yield return new WaitForSeconds(6.5f);
        FadeOutCover.SetActive(true);
        m_Animator = FadeOutCover.GetComponent<Animator>();
        m_Animator.SetTrigger("FadeOutStart");
        yield return new WaitForSeconds(2);
        Title.SetActive(true);
        ReStart.SetActive(true);

    }

}
