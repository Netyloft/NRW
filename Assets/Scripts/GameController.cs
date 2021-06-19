using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject end;
    [SerializeField] private GameObject start;

    private void GameOver()
    {
        end.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        start.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    private void OnEnable()
    {
        MainObject.MainDestroy += GameOver;
    }

    private void OnDisable()
    {
        MainObject.MainDestroy -= GameOver;
    }
}
