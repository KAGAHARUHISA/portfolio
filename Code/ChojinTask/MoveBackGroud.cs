using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MoveBackGround : MonoBehaviour
{
    private const float k_maxLength = 1f;
    private const string k_propName = "_MainTex";

    //  背景の移動スピード
    [SerializeField] private Vector2 m_offsetSpeed;

    private Material m_copiedMaterial;

    private void Start()
    {
        var image = GetComponent<Image>();

        //  マテリアルをコピーしてオブジェクトが消されてもいいようにする
        m_copiedMaterial = new Material(image.material);
        image.material = m_copiedMaterial;

        // マテリアルがnullだったら例外が出ます。
        Assert.IsNotNull(m_copiedMaterial);
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }

        // xとyの値が0 ～ 1でリピートするようにする
        var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, k_maxLength);
        var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, k_maxLength);
        var offset = new Vector2(x, y);
        m_copiedMaterial.SetTextureOffset(k_propName, offset);
    }

    private void OnDestroy()
    {
        // ゲームオブジェクト破壊時にマテリアルのコピーも消しておく
        Destroy(m_copiedMaterial);
        m_copiedMaterial = null;
    }
}