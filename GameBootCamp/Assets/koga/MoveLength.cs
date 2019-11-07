using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLength : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movetext;
    [SerializeField] private GameObject chaser;
    [SerializeField] private GameObject chaseDistancetext;
    [SerializeField] private Vector3 keeppos;
    [SerializeField] private Vector3 movepos;
    [SerializeField] private float chasevec;

    // Start is called before the first frame update
    void Start()
    {
        keeppos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //移動距離
        movepos = player.transform.position - keeppos;

        //追う者との距離
        chasevec = player.transform.position.x - chaser.transform.position.x;

        DrawMovePos();
        DrawChaserLength();
    }

    private void DrawMovePos()
    {
        Text move = movetext.GetComponent<Text>();
        move.text = "移動距離" + movepos.x;
    }
    
    private void DrawChaserLength()
    {
        Text distancetext = chaseDistancetext.GetComponent<Text>();
        distancetext.text = "追う者との距離" + chasevec;
    }
}
