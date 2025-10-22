using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInEnemyLandCheck : MonoBehaviour
{
    //  �Q�[���I�u�W�F�N�g���L�[�Ƃ����^�O���̘A�z�z��
    Dictionary<GameObject, string> TOUCHING_LAND = new Dictionary<GameObject, string>();

    //  �v���C���[�̐G��Ă���̒n���S�Ď����̗̒n���ۂ��̃t���O
    bool IS_IN_MYLAND = true;

    bool gameStart = false;

    private void Awake()
    {
        gameStart = false;
        StartCoroutine("GameStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            //  �G��Ă���̒n�Ɏ����̂��̂��Ȃ�������HP ��0�ɂ���
            if (this.name == "Player_1P")
            {
                //Debug.Log(TOUCHING_LAND.Count);
                IS_IN_MYLAND = TOUCHING_LAND.Values.Contains("Player1Land");

                if (!IS_IN_MYLAND)
                {
                    PlayerHPscript PLAYERHP = GetComponent<PlayerHPscript>();
                    PLAYERHP.Player_HP = 0;
                }
            }
            else if (this.name == "Player_2P")
            {
                //Debug.Log(TOUCHING_LAND.Count + ";2P");
                IS_IN_MYLAND = TOUCHING_LAND.Values.Contains("Player2Land");

                if (!IS_IN_MYLAND)
                {
                    Player2PHPScript PLAYERHP = GetComponent<Player2PHPScript>();
                    PLAYERHP.Player2p_HP = 0;
                }
            }
        }  
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        gameStart = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  �G�ꂽ�p�l����A�z�z��̒��ɕ��荞��
        if (collision.tag == "Player1Land" || collision.tag == "Player2Land")
        {
            TOUCHING_LAND.Add(collision.gameObject, collision.tag);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player1Land" || collision.tag == "Player2Land")
        {
            //  �G��Ă���p�l���Ɣz����̃L�[�ƂȂ�p�l��������Ȃ̂Ƀ^�O�����قȂ������ɏ��������s
            if (TOUCHING_LAND[collision.gameObject] != collision.tag)
            {
                //  �z����̃^�O�����㏑��
                TOUCHING_LAND[collision.gameObject] = collision.tag;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //  ���ꂽ�p�l����z�񂩂����
        if (collision.tag == "Player1Land" || collision.tag == "Player2Land")
        {
            TOUCHING_LAND.Remove(collision.gameObject);
        }
    }
}
