using UnityEngine;

public class UpCannon : MonoBehaviour
{
    public GameObject projectilePrefab; // ���˂���e�ۂ̃v���n�u
    public float fireForce = 10f;       // ���˂����
    public float fireInterval = 2f;     // ���ˊԊu�i�b�j

    private float timer;                // ���ˊԊu�̃^�C�}�[

    void Start()
    {
        timer = fireInterval;           // �^�C�}�[�̏�����
    }

    void Update()
    {
        // �^�C�}�[���X�V
        timer -= Time.deltaTime;

        // �^�C�}�[��0�ȉ��ɂȂ����甭�˂���
        if (timer <= 0)
        {
            Fire();
            // �^�C�}�[���Đݒ肷��
            timer = fireInterval;
        }
    }

    // �e�ۂ𔭎˂��郁�\�b�h
    void Fire()
    {
        // �e�ۂ̐����ʒu��������ɂ��炷
        Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0);

        // �e�ۂ̃C���X�^���X�𐶐����A�ʒu�Ɖ�]���C�ɍ��킹��
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, transform.rotation);

        // Rigidbody���擾���A�͂������ď�����ɔ��˂���
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * fireForce, ForceMode2D.Impulse);
        }
    }
}
