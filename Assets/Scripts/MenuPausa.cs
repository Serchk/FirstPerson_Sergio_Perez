using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    void Start()
    {
        //canvasPausa = GetComponent<Canvas>();
    }
    void Update()
    {
        //if (Input.GetKeyDown(Escape))
        //{
        //    //canva
        //}
    }
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); Para cuando tienes varios niveles
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }
    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        //Application.Quit();
    }
}
