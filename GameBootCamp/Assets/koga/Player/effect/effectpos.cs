using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectpos : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HiteffectPos(Vector2 push)
    {
        transform.position = player.transform.position + new Vector3(push.x, push.y + 0.5f, 0);
    }
}
