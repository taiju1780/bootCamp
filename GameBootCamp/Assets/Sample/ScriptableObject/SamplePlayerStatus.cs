using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サンプルプレイヤーのステータス
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObject/SamplePlayerData")]
public class SamplePlayerStatus : ScriptableObject
{
    public string samplePlayerName;
    public int samplePlayerStartHP;
    public int samplePlayerStartSP;
}
