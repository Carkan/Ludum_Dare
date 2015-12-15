using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationFleche : MonoBehaviour {


    public Image myImage;
    public Sprite mySprite;
    public GameObject canvas;


    void Update () {

        if (Input.GetButtonDown("A_0"))
        {
            myImage.sprite = mySprite;
            ButtonRestart();
        }
    }

    public void ButtonRestart()
    {
        Application.LoadLevelAsync("Main");
        canvas.SetActive(true);
    }
}
