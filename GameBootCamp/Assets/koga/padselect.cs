using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class padselect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Selectable select = GetComponent<Selectable>();
        select.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
