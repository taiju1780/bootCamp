using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private bool rotaright;
    private bool rotaleft;
    private bool rotaup;
    private bool rotadown;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float rotaHorizontal = Input.GetAxis("Horizontal2");
        float rotaVertical = Input.GetAxis("Vertical2");

        if (rotaHorizontal == 1.0f)
        {
        }
        if (rotaHorizontal == -1.0f)
        {

        }
        if (rotaVertical == 1.0f)
        {

        }
        if (rotaVertical == -1.0f)
        {

        }


        transform.Rotate(new Vector3(0, rotaHorizontal, 0));
    }
}
