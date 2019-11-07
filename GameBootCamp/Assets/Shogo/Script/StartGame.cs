//-------------------------------------
// Script  : StartGame
// Name    : ゲームを始めるかどうか
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    static bool isStartGame;

    private int startTime;

    // セッター
    public static void SetStartGame(bool _isSet)
    {
        isStartGame = _isSet;
    }

    // ゲッター
    public static bool GetStartGame()
    {
        return isStartGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ゲームを始めない
        isStartGame = false;
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        startTime++;

        if(startTime > 600)
        {
            isStartGame = true;
        }
    }
}
