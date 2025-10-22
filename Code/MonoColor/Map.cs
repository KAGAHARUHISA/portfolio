using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting.FullSerializer;
using static Unity.Collections.AllocatorManager;

public class Map : MonoBehaviour
{
    Transform PANEL_OF_PARENT;      //  �p�l���̐e���i�[����g�����X�t�H�[���^�̕ϐ�(�p�l���̐e�͂��̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g)

    public GameObject BLACK_PLAYERTILE;         //�����p�l��(Player1)
    public GameObject WHITE_PLAYERTILE;         //�����p�l��(Player2)

    int PANELPLACE_X = -945;  //�ŏ��ɔz�u�����p�l����X���W
    int PANELPLACE_Y = 525;  //�ŏ��ɔz�u�����p�l����Y���W
    Vector2 PANEL_PLACE = new Vector2();    //�z�u�����p�l���̈ʒu

    [SerializeField] TextAsset MAP_CSVFILE; // CSV�t�@�C��
    private List<string[]> MAP_CSVDATA = new List<string[]>(); // CSV�t�@�C���̒��g�����郊�X�g

    // Start is called before the first frame update
    void Start()
    {
        PANEL_OF_PARENT = GetComponent<Transform>();              // �ϐ��ɂ��̃I�u�W�F�N�g��Transform���i�[
        StringReader READER = new StringReader(MAP_CSVFILE.text); // TextAsset��StringReader�ɕϊ�

        while (READER.Peek() != -1)
        {
            string line = READER.ReadLine(); // 1�s���ǂݍ���
            MAP_CSVDATA.Add(line.Split(',')); // MAP_CSVDATA���X�g�ɒǉ�����
            PANEL_PLACE = new Vector2(PANELPLACE_X, PANELPLACE_Y);  //  �p�l���̍��W���w��
        }

        for (int i = 0; i <36; i++) //  ���̗v�f���m�F���ă}�b�v�̃^�C�����o��������
        {

            for (int j = 0; j < 64; j++)
            {

                if (MAP_CSVDATA[i][j] == "0")   //  ���p�l���̎�
                {
                    GameObject BLACK = Instantiate(BLACK_PLAYERTILE, PANEL_PLACE, Quaternion.identity);�@�@ //    �p�l���̏o��
                    BLACK.transform.SetParent(PANEL_OF_PARENT);                                             //  �@�o�����p�l�������̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g�̎q�ɂ���
                }
                else if (MAP_CSVDATA[i][j] == "1")�@//  ���p�l���̎�
                {
                    GameObject WHITE = Instantiate(WHITE_PLAYERTILE, PANEL_PLACE, Quaternion.identity);     //    �p�l���̏o��
                    WHITE.transform.SetParent(PANEL_OF_PARENT);                                            //  �@�o�����p�l�������̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g�̎q�ɂ���
                }

               PANEL_PLACE.x += 30;     //  ���ɐݒu����p�l����X���W�����̕�����30���炷����

                if (j == 63)    //  ����񕪂̃p�l����z�u�����玟�ɔz�u����p�l����X���W�����̗�̂P���ڂƓ����ɂ���
                {
                    PANEL_PLACE.x = -945; //  �����ŕύX
                }
            }

            PANEL_PLACE.y -= 30;    //  ���̗�ɔz�u����p�l���̂��߂�Y���W�𕉂̕�����30���炷
        }

    }

  
}
