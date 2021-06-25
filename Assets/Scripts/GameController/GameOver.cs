using System;
using System.Collections;
using System.Collections.Generic;
using GameController;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = GameManager.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
