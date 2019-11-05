using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveLength : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject movetext;
    [SerializeField] private Vector3 keeppos;
    [SerializeField] private Vector3 movepos;

    // Start is called before the first frame update
    void Start()
    {
        keeppos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movepos = player.transform.position - keeppos;
        DrawMovePos();
    }

    private void DrawMovePos()
    {
        Text move = movetext.GetComponent<Text>();
        move.text = "移動距離" + movepos.x;
    }
}
