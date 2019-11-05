//-------------------------------------
// Script  : CreateTogeToge
// Name    : とげの作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 04
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTogeToge : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤー")]
    GameObject player;

    [SerializeField, Tooltip("プレイヤーから離して出す")]
    float initCrowPosition;

    [SerializeField, Tooltip("とげとげオブジェクト")]
    GameObject TogeObs;

    [SerializeField, Tooltip("とげとげオブジェクトの有効範囲")]
    Vector2 randomRange;

    [SerializeField, Tooltip("サイズ")]
    Vector3 size;
    [SerializeField, Tooltip("初期位置")]
    Vector3 initPosition;

    int time;
    bool isCreate;

    const int createTime = 600;

    // とげとげ作成
    void CreatingTogeToge()
    {
        Instantiate(TogeObs, new Vector3(player.transform.position.x + 8.0f, -2, 0.0f) + initPosition, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = size;

        // 各初期化
        isCreate = false;
        time = 0;

        // とげとげの作成
        CreatingTogeToge();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間ごとの出現
        time++;

        if (time > createTime)
        {
            time = 0;
            isCreate = true;
        }

        if (isCreate)
        {
            CreatingTogeToge();
            isCreate = false;
        }

    }
}
