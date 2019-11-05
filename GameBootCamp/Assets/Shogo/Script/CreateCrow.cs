//-------------------------------------
// Script  : CreateCrow
// Name    : カラスの作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 04
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateCrow : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤー")]
    GameObject player;

    [SerializeField, Tooltip("プレイヤーから離して出す")]
    float initCrowPosition;

    [SerializeField,Tooltip("カラス")]
    GameObject crowObs;

    [SerializeField,Tooltip("カラスの有効範囲")]
    Vector2 randomRange;

    [SerializeField, Tooltip("サイズ")]
    Vector3 size;
    [SerializeField, Tooltip("初期位置")]
    Vector3 initPosition;

    int time;
    bool isCreate;

    const int createTime = 180;

    // カラス作成
    void CreatingCrow()
    {
        Instantiate(crowObs, new Vector3(player.transform.position.x + initCrowPosition, Random.Range(-randomRange.x, randomRange.y), -2.0f) + initPosition, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = size;
        // 各初期化
        isCreate = false;
        time = 0;

        // カラスの作成
        CreatingCrow();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間ごとの出現
        time++;

        if(time > createTime)
        {
            time = 0;
            isCreate = true;
        }

        if(isCreate)
        {
            CreatingCrow();
            isCreate = false;
        }
    }
}
