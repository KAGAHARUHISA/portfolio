using UnityEngine;

public class FireBar : MonoBehaviour
{
    public int numberOfBalls = 10;          // �{�[���̐��i�t�@�C���[�o�[�̒����j
    public float rotationSpeed = 90.0f;     // ��]���x�i�x/�b�j
    public float moveDistance = 1.0f;       // �㉺�ɐU�����鋗��
    public float moveSpeed = 1.0f;          // �U�����x
    public float scaleIncreaseAmount = 1.0f; // Y�����ɑ�������X�P�[���̗�
    public GameObject ballPrefab;           // �{�[���̃v���n�u

    private GameObject[] balls;             // �{�[���̔z��
    private Vector3 initialScale;           // �����X�P�[��
    private Vector3 initialPosition;        // �����ʒu
    private float startTime;                // �U���J�n����

    void Start()
    {
        initialScale = transform.localScale;  // �����X�P�[����ۑ�
        initialPosition = transform.position; // �����ʒu��ۑ�
        startTime = Time.time;                // �U���J�n���Ԃ��L�^

        // �{�[���̔z����쐬
        balls = new GameObject[numberOfBalls];

        // �{�[���𐶐����Ĕz�u����
        for (int i = 0; i < numberOfBalls; i++)
        {
            float angle = i * (360.0f / numberOfBalls);
            Vector3 offset = Quaternion.Euler(0, 0, angle) * Vector3.right * 0.5f;
            GameObject ball = Instantiate(ballPrefab, transform.position + offset, Quaternion.identity, transform);
            balls[i] = ball;
        }
    }

    void Update()
    {
        // ��]�^�����s���iZ������j
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // �㉺�̐U�����s��
        float elapsedTime = Time.time - startTime;
        float yPos = Mathf.Sin(elapsedTime * moveSpeed) * moveDistance;
        transform.position = initialPosition + Vector3.up * yPos;

        // Y�����ɃX�P�[���𑝉�����
        float scaleFactor = 1.0f + scaleIncreaseAmount;
        Vector3 newScale = initialScale;
        newScale.y *= scaleFactor;
        transform.localScale = newScale;
    }

    void OnValidate()
    {
        // �C���X�y�N�^�[�E�B���h�E�Œl���ύX���ꂽ�Ƃ��ɁA�����X�P�[�����X�V
        initialScale = transform.localScale;
    }
}
