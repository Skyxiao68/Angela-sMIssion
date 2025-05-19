//Wrote this myself on 15 May 2025

using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
  public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
