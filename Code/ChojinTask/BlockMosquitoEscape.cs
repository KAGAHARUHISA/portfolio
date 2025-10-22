using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMosquitoEscape : MonoBehaviour
{
    //  上下の壁に当たった時の移動量
    [SerializeField] private float _movePosition;

    //  詳細パネルで上の壁か否かを分ける
    [SerializeField] private bool _isTopWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mosquito"))    //  蚊が上下枠外から出ないようにする処理
        {
            MosquitoMove mosquitoMove = collision.GetComponent<MosquitoMove>();
            mosquitoMove._upSpeed *= -1;
        }
        else　// UFOが上下枠外から出ないようにする処理
        {
            UFOMove ufoMove = collision.GetComponent<UFOMove>();
            if (ufoMove != null )
            {
                RectTransform rectTransform = collision.gameObject.GetComponent<RectTransform>();
                Vector3 ufoPos = rectTransform.position;

                //  UFOのすり抜けが発生しない様に調整
                if (_isTopWall) //  上の壁に当たった時
                {
                    ufoPos.y -= _movePosition;
                }
                else // 下の壁に当たった時
                {
                    ufoPos.y += _movePosition;
                }

                rectTransform.position = ufoPos;

                //  当たった壁の反対に進むようにする
                ufoMove._upSpeed *= -1;
            }
        }
        
    }
}
