using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationFleche : MonoBehaviour {


    public Image myImage;
    public Sprite mySprite;


    void Update () {
        transform.Rotate(0, 0, 2f);

        if (Input.GetButtonDown("A_0"))
        {
            myImage.sprite = mySprite;
            ButtonRestart();
        }
    }

    public void ButtonRestart()
    {
        Application.LoadLevel("Main");
    }
}
