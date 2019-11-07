//-------------------------------------
// Script  : StartGame
// Name    : ゲームを終わるかどうか
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    static bool isEndTimeGame;
    static bool isEndGame;

    private int  endTime;

    // セッター
    public static void SetEndtGame(bool _isSet)
    {
        isEndGame = _isSet;
    }
    public static void SetEndTimeGame(bool _isSet)
    {
        isEndTimeGame = _isSet;
    }
    // ゲッター
    public static bool GetEndGame()
    {
        return isEndGame;
    }
    public static bool GetEndTimeGame()
    {
        return isEndTimeGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        isEndGame = false;
        isEndTimeGame = false;
        endTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndTimeGame)
        {
            endTime++;
        }

        if (endTime > 320)
        {
            isEndGame = true;
        }
    }
}
