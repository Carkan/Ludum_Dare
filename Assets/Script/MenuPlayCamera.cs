using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuPlayCamera : MonoBehaviour {


    public Image myImage;
    public Sprite mySprite;
    public GameObject loadingScreen;
    public GameObject titleScreen;
    bool isLoading;


    void Update()
    {
        transform.Rotate(0, 0.1f, 0);
        if(!isLoading)
        {
            if (Input.GetButtonDown("A_0"))
            {
                myImage.sprite = mySprite;
                isLoading = true;
                ButtonRestart();
            }
        }
    }

    public void ButtonRestart()
    {
        Application.LoadLevelAsync("Main");
        loadingScreen.SetActive(true);
        titleScreen.SetActive(false);
    }
}
