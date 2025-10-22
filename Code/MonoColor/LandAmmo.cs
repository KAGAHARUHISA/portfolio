using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandAmmo : MonoBehaviour
{
    //  �Ⴄ�p�l���ɐG�ꂽ���ǂ����̃t���O
    private bool ISTOUCHED_DIFFERENCEPANEL = false;

    //  �G��Ă���p�l�����i�[���郊�X�g
    List<Collider2D> PANELS = new List<Collider2D>();

    //  �p�l���ɐG�ꂽ���̗̓y�e��X���W��ێ�����ϐ�
    //private float PAST_X;

    //  �G�p�l���ɐG�ꂽ��̒e��X���W�𖈃t���[���i�[����ϐ�
    //private float NOW_X;

    //  ���ꂪ�A�^�b�`����Ă���e�̕��̑傫�����i�[����ϐ�
    //private float WIDTH;

    public AudioClip paintsound;

    AudioSource audioSource;

    //  ��������G�t�F�N�g���i�[
    //public GameObject LAND_EFFECT;
    //public GameObject SUDDENDEATH_LAND_EFFECT;

    //  �G�t�F�N�g���X�|�[������܂ł̎���
    public float EFFECT_SPAWN_TIME = 0.75f;
    public float SUDDENDEATH_EFFECT_SPAWN_TIME = 0.25f;

    private void Start()
    {
        //  ���̃I�u�W�F�N�g�̕����i�[
        //WIDTH = this.GetComponent<RectTransform>().sizeDelta.x;

        ////  �G�̃p�l���ɓ����肻���ɂȂ������玩�R����
        //StartCoroutine(SelfDestroy());

        //  �������擾
        audioSource = GetComponent<AudioSource>();

        IsSuddenDeathCheckForEffect SUDDENDEATH_CHECK = GameObject.Find("JudgeManager").GetComponent<IsSuddenDeathCheckForEffect>();
        bool IS_SUDDENDEATH = SUDDENDEATH_CHECK.isSuddenDeath;

        //     �T�h���f�X���ǂ����Ő�������G�t�F�N�g�����߂�
        StartCoroutine(SpawnLandEffect(SUDDENDEATH_CHECK));
    }

    //  �G�ꂽ�p�l�������X�g�Ɋi�[
    public void OnTriggerEnter2D(Collider2D TOUCHING_PANEL)
    {
        //  �p�l���̂ݎ��e
        if (TOUCHING_PANEL.CompareTag("Player1Land") || TOUCHING_PANEL.CompareTag("Player2Land"))
        {

            PANELS.Add(TOUCHING_PANEL);

            //  �����G�ꂽ�p�l�����G�̃p�l����������h����J�n
            if (this.CompareTag("BLACKPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player2Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.black, "Player1Land");
            }
            else if (this.CompareTag("WHITEPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player1Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.white, "Player2Land");
            }
        }
        else if (TOUCHING_PANEL.CompareTag("BLACKPLAYER_AMMO") || TOUCHING_PANEL.CompareTag("WHITEPLAYER_AMMO"))    //  �h��e���m�̑��E
        {
            Destroy(TOUCHING_PANEL);
            Destroy(this.gameObject);
        }
    }

    //   �O�̂��ߓh��Ă��Ȃ��p�l����h�邽�߂̏���
    private void OnTriggerStay2D(Collider2D TOUCHING_PANEL)
    {
        if (TOUCHING_PANEL.CompareTag("Player1Land") || TOUCHING_PANEL.CompareTag("Player2Land"))
        {

            //  �����G�ꂽ�p�l�����G�̃p�l����������h����J�n
            if (this.CompareTag("BLACKPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player2Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.black, "Player1Land");
            }
            else if (this.CompareTag("WHITEPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player1Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.white, "Player2Land");
            }
        }
    }

    //  ���ꂽ�p�l�������X�g����폜
    private void OnTriggerExit2D(Collider2D EXIT_PANEL)
    {
        //  ���X�g����A����Ă������p�l�����폜
        PANELS.Remove(EXIT_PANEL);

        //  ���X�g���̃p�l���ɑł��o���ꂽ�̓y�e�Ɠ����F�̃p�l�������邩���m�F����B
        if (this.CompareTag("BLACKPLAYER_AMMO") && IS_SAMECOLORPANEL(Color.black))
        {
            ISTOUCHED_DIFFERENCEPANEL = false;
        }
        else if (this.CompareTag("WHITEPLAYER_AMMO") && IS_SAMECOLORPANEL(Color.white))
        {
            ISTOUCHED_DIFFERENCEPANEL = false; //���������̂�true�������B
        }

    }

    private void Update()
    {

        //if (ISTOUCHED_DIFFERENCEPANEL)
        //{
        //    //NOW_X = this.transform.position.x;
        //    //  �G�̐w�n�ɒe�̑傫�������i�񂾂����m�F
        //    if (Mathf.Abs(PAST_X - NOW_X) >= WIDTH)
        //    {
        //        if (this.CompareTag("BLACKPLAYER_AMMO"))
        //        {
        //            CHANGE_PANELCOLOR(Color.black, "Player1Land");
        //        }
        //        else
        //        {
        //            CHANGE_PANELCOLOR(Color.white, "Player2Land");
        //        }
        //    }
        //}
    }


    #region ���X�g�̒��ɒe�Ɠ����F�̃p�l�������邩�m�F����֐�

    private bool IS_SAMECOLORPANEL(Color COLOR)
    {

        //  ���X�g�̗v�f���̕������v�f�̐F�𒲍�
        foreach (var CHECK_PANEL in PANELS)
        {
            if (CHECK_PANEL.GetComponent<Image>().color == COLOR) //    �����F�̃p�l������������true��Ԃ�
            {
                return true;
            }
        }
        return false;   //  �����F�̃p�l�����Ȃ�������false��Ԃ�
    }
    #endregion

    #region ���X�g���̃p�l����̓y�e�̐F�ɐ��߂ă^�O���ς���֐�

    private void CHANGE_PANELCOLOR(Collider2D PANEL, Color CHANGECOLOR, string TAG_NAME)
    {
      
            PANEL.GetComponent<Image>().color = CHANGECOLOR;
            PANEL.tag = TAG_NAME;
        
        ////  �G�t�F�N�g�𐶐�������A����
        //Instantiate(LAND_EFFECT, this.transform.position, Quaternion.identity);
        //Destroy(this.gameObject);
    }

    #endregion


    ////  �̓y�e�̎��R���ł̎d�g��
    //IEnumerator SelfDestroy()
    //{
    //    yield return new WaitForSeconds(30);
    //    Destroy(this.gameObject);
    //}

    //  �G�t�F�N�g�����̎d�g��
    IEnumerator SpawnLandEffect(bool IsSuddenDeath)
    {
        
        //  �ʏ펞
        if (!IsSuddenDeath)
        {
            yield return new WaitForSeconds(EFFECT_SPAWN_TIME);
            //Instantiate(LAND_EFFECT, this.transform.position, Quaternion.identity);
        }
        else�@//  �T�h���f�X��
        {
            yield return new WaitForSeconds(SUDDENDEATH_EFFECT_SPAWN_TIME);
            //Instantiate(SUDDENDEATH_LAND_EFFECT, this.transform.position, Quaternion.identity);
        }

    }

}
