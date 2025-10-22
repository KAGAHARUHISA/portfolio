using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageType : MonoBehaviour
{
    //  U‚Á‚Ä‚­‚é‚²‚İ‚Ìƒ^ƒCƒv‚ğŒˆ‚ß‚éB‚O‚È‚ç‰Â”R‚²‚İA‚P‚È‚ç‘Œ¹‚²‚İ
    public int _garbageTypeNumber;

    //  ƒSƒ~” ‚É“ü‚Á‚½Û‚ÌƒSƒ~•Ê‚ÌSE‚ğ‚±‚±‚ÉŠi”[
    [SerializeField] private AudioClip _garbageSE;

    void OnDestroy()
    {
        AudioSource audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(_garbageSE);
    }

}
