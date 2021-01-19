using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 0.5f;

    int score = 0;

    public static void LoadWinner()
    {
        SceneManager.LoadScene("WinnerScene");
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    
    public void LoadStartMenu()
    {
        //loads the first scene in the Project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads the scene with the name SampleScene
        SceneManager.LoadScene("SampleScene");

        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        
        Application.Quit();
    }

    


    
}
