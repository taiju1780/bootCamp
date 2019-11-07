using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Animator skyButton;
    [SerializeField] Animator rageButton;
    [SerializeField] Animator uniButton;
    [SerializeField] SceneChange sceneChange;

    bool inputed = false;
    float inputNum = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GameObject.Find("SceneManager").GetComponent<SceneChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputed)
        {
            if(Input.GetAxis("Horizontal2") > -0.3 && Input.GetAxis("Horizontal2") < 0.3)
            {
                inputed = false;
            }
            else
            {
                return;
            }
        }

        if(skyButton.GetBool("select"))
        {
            SkyButton();
        }
        else if(rageButton.GetBool("select"))
        {
            RageButton();
        }
        else if(uniButton.GetBool("select"))
        {
            UniButton();
        }
    }

    void SkyButton()
    {
        if(Input.GetKeyDown("joystick button 0"))
        {
            skyButton.SetTrigger("play");
            sceneChange.ChangeScene("ScenarioScene");
            rageButton.SetTrigger("notPlay");
            uniButton.SetTrigger("notPlay");
        }
        if(Input.GetAxis("Horizontal2") <= -inputNum)
        {
            skyButton.SetBool("select",false);
            uniButton.SetBool("select",true);
            inputed = true;
        }
        else if(Input.GetAxis("Horizontal2") >= inputNum)
        {
            skyButton.SetBool("select", false);
            rageButton.SetBool("select", true);
            inputed = true;
        }
    }

    void RageButton()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            rageButton.SetTrigger("play");
            sceneChange.ChangeScene("RoughWeatherStage");
            skyButton.SetTrigger("notPlay");
            uniButton.SetTrigger("notPlay");
        }
        if (Input.GetAxis("Horizontal2") < -inputNum)
        {
            rageButton.SetBool("select", false);
            skyButton.SetBool("select", true);
            inputed = true;

        }
        else if (Input.GetAxis("Horizontal2") > inputNum)
        {
            rageButton.SetBool("select", false);
            uniButton.SetBool("select", true);
            inputed = true;

        }
    }

    void UniButton()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            uniButton.SetTrigger("play");
            sceneChange.ChangeScene("UniverseStage");
            skyButton.SetTrigger("notPlay");
            rageButton.SetTrigger("notPlay");
        }
        if (Input.GetAxis("Horizontal2") < -inputNum)
        {
            uniButton.SetBool("select", false);
            rageButton.SetBool("select", true);
            inputed = true;

        }
        else if (Input.GetAxis("Horizontal2") > inputNum)
        {
            uniButton.SetBool("select", false);
            skyButton.SetBool("select", true);
            inputed = true;
        }
    }
    
}
