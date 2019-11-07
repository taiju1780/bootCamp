using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBamboo : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.parent.right * moveSpeed * Time.deltaTime;
    }
}
