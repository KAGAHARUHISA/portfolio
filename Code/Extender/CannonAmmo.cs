using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonAmmo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �Փ˂����I�u�W�F�N�g���������肷��
        // �����ł̓^�O���g���Ĕ��肵�Ă��܂����A���̕��@������܂�

        if (other.CompareTag("StageFloor"))
        {
          
            // �Փ˂����I�u�W�F�N�g���v���C���[��G�A��Q���Ȃǂł���ꍇ�ACannon_Ammo�I�u�W�F�N�g��j������
            Destroy(gameObject);

        }

        if (other.CompareTag("PlayerCharacter"))
        {
            SceneManager.LoadScene("GameOver_Scene");
        }


    }
}
