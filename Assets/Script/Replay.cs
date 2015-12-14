using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Replay : MonoBehaviour {
    
    public Image myImage;
    public Sprite mySprite;

    void Update () {

        if (Input.GetButtonDown("A_0"))
        {
            myImage.sprite = mySprite;
            ButtonReplay();
        }
    }

    public void ButtonReplay()
    {
        Application.LoadLevel("Main");
    }
}
