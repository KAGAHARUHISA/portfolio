using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour
{
    //  ‰Šú‚Ì‰¡•ûŒü‚Æc•ûŒü‚ÌˆÚ“®‘¬“x
    public float _besideSpeed, _upSpeed;

    //  ‰¡•ûŒü‚Æc•ûŒü‚ÌˆÚ“®‘¬“x‚ÌÅ¬’l
    [SerializeField] float _besideSpeedMin, _upSpeedMin;

    //  ‰¡•ûŒü‚Æc•ûŒü‚ÌˆÚ“®‘¬“x‚ÌÅ‘å’l
    [SerializeField] float _besideSpeedMax, _upSpeedMax;

    //  ã‰º‚É“®‚©‚·‚Ì‚É’¼ÚŠÖ‚í‚é•Ï”
    float _upManager;

    void Start()
    {
        StartCoroutine(ChangeBesideSpeed());
        StartCoroutine(ChangeUpSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        //  sin‚ğ—p‚¢‚ÄUFO‚ğã‰º‚É“®‚©‚·
        _upManager = Mathf.Sin(Time.time);

        //  UFO‚Ì‹““®‚Ì§Œä
        transform.Translate(_besideSpeed * Time.deltaTime, _upSpeed * _upManager * Time.deltaTime, 0);
    }

    //  ‰¡•ûŒü‚ÌˆÚ“®‘¬“x‚Ìƒ‰ƒ“ƒ_ƒ€•Ï‰»
    IEnumerator ChangeBesideSpeed()
    {
        float changeBesideSpeedSpan = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(changeBesideSpeedSpan);
        _besideSpeed = Random.Range(_besideSpeedMin, _besideSpeedMax) * ContinueUFOBesideVector();
        StartCoroutine(ChangeBesideSpeed());
    }

    //  c•ûŒü‚ÌˆÚ“®‘¬“x‚Ìƒ‰ƒ“ƒ_ƒ€•Ï‰»
    IEnumerator ChangeUpSpeed()
    {
        float changeUpSpeedSpan = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(changeUpSpeedSpan);
        _upSpeed = Random.Range(_upSpeedMin, _upSpeedMax);
        StartCoroutine(ChangeUpSpeed());
    }

    //  •Ï‚ÈˆÚ“®•ûŒüØ‚è•Ô‚µ‚ğ‘j~‚·‚éŠÖ”
    public short ContinueUFOBesideVector()
    {
        if (_besideSpeed < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }

    //  ’Eo”»’è‚ğ‚Â•Ç‚É“–‚½‚Á‚½‚çˆÚ“®•ûŒü‚ª”½“]‚·‚éˆ—
    public void UFOReturn()
    {
        //  ˆÚ“®•ûŒü”½“]
        _besideSpeed *= -1;
    }
}
