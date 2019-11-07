using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScenarioScript : MonoBehaviour
{
    [SerializeField] List<Sprite> list = new List<Sprite>();

    bool beforeInput;
    int spriteNum = 0;
    Image image;
    SceneChange sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        beforeInput = false;
        image = GameObject.Find("ScenarioImage").GetComponent<Image>();
        
        image.sprite = list[spriteNum];
        sceneChange = GameObject.Find("SceneManager").GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if(beforeInput)
        {
            if (!Input.anyKey)
            {
                beforeInput = false;
            }
        }
        else
        {
            if (Input.anyKey)
            {
                beforeInput = true;
                spriteNum++;
                if(spriteNum >= list.Count)
                {
                    //ゲーム開始
                    sceneChange.ChangeScene();
                }
                else
                {
                    image.sprite = list[spriteNum];
                }
            }
        }
    }
}
