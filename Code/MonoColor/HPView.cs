using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPView : MonoBehaviour
{

    //  各プレイヤーの自機のオブジェクトを格納する変数
    public GameObject PLAYER1;
    public GameObject PLAYER2;

    //  自機オブジェクトにアタッチされているスクリプト"PlayerHP"内にある変数PLAYER_HPを格納する変数
    private int PLAYER1_HP;
    private int PLAYER2_HP;

    //  各プレイヤーのHPUIオブジェクトを格納する変数
    //  プレイヤー１用
    public GameObject FIRSTHP_PLAYER1;
    public GameObject SECONDHP_PLAYER1;

    //  プレイヤー２用
    public GameObject FIRSTHP_PLAYER2;
    public GameObject SECONDHP_PLAYER2;

    //  ダメージを受けた事を示すHPUIの画像を格納する変数
    public Sprite DAMAGED_PLAYER1HP;
    public Sprite DAMAGED_PLAYER2HP;


    //  植草　改訂
    [SerializeField] private float invincibleTime; // 無敵時間の長さ
    [SerializeField] private float blinkInterval; // 点滅間隔
    [SerializeField] private Image[] targetimages; // 対象オブジェクトのレンダラー
    [SerializeField] private Image[] targetimages2; // 対象オブジェクトのレンダラー
    [SerializeField] private float invincibleDuration = 3f; // 無敵状態の持続時間
    private bool isInvincible; // 無敵状態かどうか
    private bool isInvincible2; // プレイヤー2が無敵状態かどうか
    private float invincibleTimer; // 無敵時間のカウントダウン
    private float invincibleTimerPlayer2; // 無敵時間のカウントダウン
    [SerializeField] private string newTag = "Damage";
    private string originalTag1;
    private string originalTag2;
    //private bool damege = false;

    public AudioClip hitsound;

    public AudioSource audioSource;

    //[SerializeField] private PlayerControl _playerControl;

    private void Start()
    {
        //  音声を取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //originalTag1 = PLAYER1.tag;
        
        // 無敵時間の処理
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
                //  タグを変えて当たり判定を消す
                PLAYER1.tag = originalTag1;
                Debug.Log("無敵時間終了");
                //damege = true;
            }
        }
        // 無敵時間の処理
        if (isInvincible2)
        {
            invincibleTimerPlayer2 -= Time.deltaTime;
            if (invincibleTimerPlayer2 <= 0)
            {
                isInvincible2 = false;
                //  タグを変えて当たり判定を消す
                PLAYER2.tag = originalTag2;
                Debug.Log("無敵時間終了");
                //damege = true;
            }
        }
        //if (_playerControl._suddenDeath)
       // {
            //damege = true;
        //}
    }

    public void ChangeHPViwer()
    {
        //  プレイヤー１のHPUIを変更
        if (PLAYER1_HP == 1)
        {
            Image DAMAGED_UI = FIRSTHP_PLAYER1.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER1HP;
            audioSource.PlayOneShot(hitsound);

        }
        else if (PLAYER1_HP == 0)
        {
            Debug.Log("a");
            Image DAMAGED_UI = SECONDHP_PLAYER1.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER1HP;
            ActivateIncibility();
            //  タグを変えて当たり判定を消す
            originalTag1 = PLAYER1.tag;
            PLAYER1.tag = newTag;
            audioSource.PlayOneShot(hitsound);
            StartCoroutine(InvincibleCoroutine());
        }
    }

    public void ChangeHPViwerPlayer2()
    {

        //  プレイヤー２のHPUIを変更
        if (PLAYER2_HP == 1)
        {
            Image DAMAGED_UI = FIRSTHP_PLAYER2.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER2HP;
            audioSource.PlayOneShot(hitsound);
        }
        else if (PLAYER2_HP == 0)
        {
            Debug.Log("a");
            Image DAMAGED_UI = SECONDHP_PLAYER2.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER2HP;
            ActivateIncibilityPlayer2();
            //  タグを変えて当たり判定を消す
            originalTag2 = PLAYER2.tag;
            PLAYER2.tag = newTag;
            Debug.Log(PLAYER2.tag);
            audioSource.PlayOneShot(hitsound);
            StartCoroutine(InvincibleCoroutine2());
        }
    }

    IEnumerator InvincibleCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < invincibleTime)
        {
            // 各Rendererのenabledを切り替えて点滅効果を作る
            foreach (var image in targetimages)
            {
                if (image != null)
                {
                    image.enabled = !image.enabled; // 点滅させる
                }
            }

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // 各Rendererを表示状態に戻す
        foreach (var image in targetimages)
        {
            if (image != null)
            {
                image.enabled = true;
            }
        }
    }

    IEnumerator InvincibleCoroutine2()
    {
        float elapsedTime = 0f;
        while (elapsedTime < invincibleTime)
        {
            // 各Rendererのenabledを切り替えて点滅効果を作る
            foreach (var image in targetimages2)
            {
                if (image != null)
                {
                    image.enabled = !image.enabled; // 点滅させる
                }
            }

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // 各Rendererを表示状態に戻す
        foreach (var image in targetimages2)
        {
            if (image != null)
            {
                image.enabled = true;
            }
        }
    }
    //無敵時間開始処理
    public void ActivateIncibility()
    {
        isInvincible = true;
        invincibleTimer = invincibleDuration;
    }

    //無敵時間開始処理
    public void ActivateIncibilityPlayer2()
    {
        isInvincible2 = true;
        invincibleTimerPlayer2 = invincibleDuration;
    }
}
