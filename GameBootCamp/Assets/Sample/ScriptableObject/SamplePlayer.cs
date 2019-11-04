using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サンプル
/// </summary>
namespace Sample
{
    public class SamplePlayer : MonoBehaviour
    {
        [SerializeField] SamplePlayerStatus status;     //プレイヤーステータス
        private int hp;                                 //サンプルプレイヤーのHP
        private int sp;                                 //サンプルプレイヤーのSP

        // Start is called before the first frame update
        void Start()
        {
            name    = status.samplePlayerName;
            hp      = status.samplePlayerStartHP;
            sp      = status.samplePlayerStartSP;

//エディタで実行したときのみ実行
#if UNITY_EDITOR
            Debug.Log("Name = " + name);
            Debug.Log("HP = " + hp);
            Debug.Log("SP = " + sp);
#endif
        }
    }
}

