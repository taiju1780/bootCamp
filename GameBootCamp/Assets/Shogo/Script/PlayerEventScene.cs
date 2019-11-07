//-------------------------------------
// Script  : PlayerEventScene
// Name    : プレイヤーのイベントシーン
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 05
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventScene : MonoBehaviour
{
    Vector3 position;
    [SerializeField, Tooltip("ムーブ")]
    Move move;
    [SerializeField, Tooltip("カメラのオンオフ")]
    Camera camera;
    GameObject target;
    Vector3 targetPos;

    int startEventTime;
    int endEventTime;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Goal");

        move.enabled = false;
        position = new Vector3(-15, 0, 0);
        targetPos = new Vector3(0, 0, 0);
        camera.enabled = true;
        startEventTime = 0;
        endEventTime = 0;
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 始まり時のプレイヤーのイベント 無理やり
        startEventTime++;

        if (startEventTime > 260)
        {
            move.enabled = true;
            camera.enabled = false;
        }
        else
        {
            // 回転
            gameObject.transform.Rotate(new Vector3(0, 1800, 0) * Time.deltaTime);
        }

        if (startEventTime < 220)
        {
            position.x += 0.04f;
            transform.position = position;
            if(position.x > 0)
            {
                position = new Vector3(0, 0, 0);
            }
        }

        // 終わり時のプレイヤーのイベント

        if(EndGame.GetEndTimeGame())
        {
            endEventTime++;
            move.enabled = false;


            if (endEventTime < 180)
            {
                position = transform.position;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 4 * Time.deltaTime);
            }
            if (endEventTime == 180)
            {
                targetPos = transform.position;
            }
            if (endEventTime > 180)
            {
                transform.position = targetPos;
            }
            if (endEventTime > 300)
            {
                position.x ++;
                transform.position = position;
            }
        }
    }
}
