using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChange_Next : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �Փ˂����I�u�W�F�N�g��PlayerCharacter�^�O�����ꍇ
        if (other.CompareTag("PlayerCharacter"))
        {
            // ClearScene�ɃV�[����J�ڂ���
            SceneManager.LoadScene("Stage2");
        }
    }
}
