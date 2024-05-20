using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public static StartScreen instance;
    private bool muted = false;




    private void Awake()
    {
        Invoke("GoGameScene", 23);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Mute()
    {
        StartScreen.instance.OnButtonPress();
    }


    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
    }
    public void GoNextScene()
    {
        SceneManager.LoadScene(1);
        GoGameScene();
    }
    public void GoGameScene()
    {
        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            SceneManager.LoadScene(2);
            
        }

        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void Save()
    {

        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
