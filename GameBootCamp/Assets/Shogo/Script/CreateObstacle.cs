//-------------------------------------
// Script  : CreateObstacle
// Name    : カラスの作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 04
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateObstacle : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤー")]
    GameObject player;

    [SerializeField, Tooltip("プレイヤーから離して出す")]
    float initObsPosition;

    [SerializeField,Tooltip("オブジェクト")]
    GameObject obs;

    [SerializeField,Tooltip("オブジェクトの有効範囲")]
    Vector2 randomRange;

    [SerializeField, Tooltip("サイズ")]
    Vector3 size;
    [SerializeField, Tooltip("初期位置")]
    Vector3 initPosition;

    [SerializeField, Tooltip("出現率")]
    int range;

    int time;
    bool isCreate;

    int createTime;

    // カラス作成
    void CreatingCrow()
    {
        Instantiate(obs, new Vector3(player.transform.position.x + initObsPosition, Random.Range(-randomRange.x, randomRange.y), -2.0f) + initPosition, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        switch(range)
        {
            case 1:
                createTime = 600;
                break;
            case 2:
                createTime = 360;
                break;
            case 3:
                createTime = 180;
                break;
        }
        gameObject.transform.localScale = size;

        // 各初期化
        isCreate = false;
        time = 0;
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

        if(isCreate && StartGame.GetStartGame() && !EndGame.GetEndTimeGame())
        {
            CreatingCrow();
            isCreate = false;
        }
    }
}
