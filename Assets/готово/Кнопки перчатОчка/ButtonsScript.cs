using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public GameObject mm, lvlchoose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        mm.SetActive(false);
        lvlchoose.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Back()
    {
        mm.SetActive(true);
        lvlchoose.SetActive(false);
    }
    public void Start1lvl()
    {
        SceneManager.LoadScene(1);
    }
    public void Start2lvl()
    {
        SceneManager.LoadScene(2);
    }
    public void Start3lvl()
    {
        SceneManager.LoadScene(3);
    }
}
