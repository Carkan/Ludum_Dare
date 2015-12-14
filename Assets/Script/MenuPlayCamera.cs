using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuPlayCamera : MonoBehaviour {

    public Image myImage;
    public Sprite mySprite;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0.1f, 0);
    
        if (Input.GetButtonDown("A_0"))
        {
            myImage.sprite = mySprite;
            ButtonStart();
        }
    }


    public void ButtonStart()
    {
        Application.LoadLevel("Main");
    }
}
