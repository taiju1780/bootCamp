using System.Collections;
using UnityEngine;

public class rotation : MonoBehaviour {
	public float xRotation = 0F;
	public float yRotation = 0F;
	public float zRotation = 0F;

    [SerializeField] private GameObject player;
	void Start(){
		InvokeRepeating("rotate", 0f, 0.0167f);
	}
	void OnDisable(){
		CancelInvoke();
	}
	public void clickOn(){
		InvokeRepeating("rotate", 0f, 0.0167f);
	}
	public void clickOff(){
		CancelInvoke();
	}
	void rotate(){
		this.transform.localEulerAngles += new Vector3(xRotation,yRotation,zRotation);
	}

    private void Update()
    {
        transform.position = player.transform.position;
    }
}
