//-------------------------------------
// Script  : CreateRing
// Name    : リングの作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 07
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRing : MonoBehaviour
{
    [SerializeField, Tooltip("オブジェクトの形 1 : A  2 : B  3 : C")]
    int objectTipe;
    [SerializeField, Tooltip("リング")]
    GameObject objectRing;

    int rand;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(1, 10);

        if (objectTipe == 1)
        {
            if (rand <= 3) { Instantiate(objectRing, transform.position + new Vector3(0, 5, 0), Quaternion.identity); }
            else if (rand > 3 && rand <= 6) { Instantiate(objectRing, transform.position + new Vector3(0, -1, 0), Quaternion.identity); }
        }

        if (objectTipe == 2)
        {
            if (rand <= 5) Instantiate(objectRing, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        }

        if (objectTipe == 3)
        {
            if (rand <= 3) { Instantiate(objectRing, transform.position + new Vector3(0, 7, 0), Quaternion.identity); }
            else if (rand > 3 && rand <= 6) { Instantiate(objectRing, transform.position + new Vector3(0, -3, 0), Quaternion.identity); }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
