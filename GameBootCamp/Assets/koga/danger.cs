using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class danger : MonoBehaviour
{
    [SerializeField] private GameObject image;
    private Image _image;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject chaser;
    private float dangerzoon = 12;
    private float supperdangerzoon = 8;
    private float effecttime = 180;
    private float wait = 0;
    [SerializeField] private bool dangerflag = false;

    // Start is called before the first frame update
    void Start()
    {
        _image = image.transform.GetComponent<Image>();
        _image.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (dangerflag == false) { 
            if (player.transform.position.x - chaser.transform.position.x <= dangerzoon)
            {
                dangerflag = true;
                this._image.color = new Color(1, 1, 1, 0.5f);
            }
        }
        if (dangerflag == true)
        {
            wait++;

            this._image.color = Color.Lerp(this._image.color, Color.clear, Time.deltaTime / 2);

            if(player.transform.position.x - chaser.transform.position.x <= supperdangerzoon)
            {
                if (effecttime / 3 <= wait)
                {
                    dangerflag = false;
                    wait = 0;
                }
            }
            else if((player.transform.position.x - chaser.transform.position.x > supperdangerzoon) && (player.transform.position.x - chaser.transform.position.x <= dangerzoon))
            {
                if (effecttime <= wait)
                {
                    dangerflag = false;
                    wait = 0;
                }
            }
        }
    }
}
