using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHit : MonoBehaviour
{

    //  ���Ă�ꂽ�v���C���[�̃I�u�W�F�N�g�̏����i�[����ϐ�
    private GameObject HITTEDPLAYER_INFOTMATION;


    private void Start()
    {
        //  ������Ȃ��������Ɏ��ԍ��Ŏ��R����
        StartCoroutine(Dont_hit());
    }


    //  �G�ɓ����������̏���
    void OnTriggerEnter2D(Collider2D HITTED_PLAYER)
    {
        //  �����G�v���C���[�ɓ���������
        if (HITTED_PLAYER.gameObject.tag == "Player"�@|| HITTED_PLAYER.gameObject.tag == "Player2")
        {
            Debug.Log("���������I");
            //  ���Ă�ꂽ�v���C���[�̃I�u�W�F�N�g�̏����i�[  
            HITTEDPLAYER_INFOTMATION = HITTED_PLAYER.gameObject;

            //  ���Ă�ꂽ����HP�X�N���v�g���i�[����ϐ��쐬���i�[
            PlayerHP HP;
            HP = HITTEDPLAYER_INFOTMATION.GetComponent<PlayerHP>();

            //  ���Ă�ꂽ����HP����鏈��
            HP.PLAYER_HP--;

            //  HPViewManager�ɃA�^�b�`����Ă���X�N���v�g���ɂ���֐����N�����AHPUI��ς���
            HPView HPVIEW;
            GameObject HPVIEW_MANAGER = GameObject.FindGameObjectWithTag("HPView_Manager");
            HPVIEW = HPVIEW_MANAGER.GetComponent<HPView>();
            HPVIEW.ChangeHPViwer();

            //�e����j��
            Destroy(this.gameObject);
        }
    }

    //  ���R����̎d�g��
    IEnumerator Dont_hit()
    {
        yield return new WaitForSeconds(60);
        Destroy(this.gameObject);
    }

   
}
