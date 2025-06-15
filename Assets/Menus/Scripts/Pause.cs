
//Make Your MAIN MENU Quickly! | Unity UI Tutorial For Beginners
//ReHope Games 
//Version 5
// 14 April 2025
// https://youtu.be/DX7HyN7oJjE?si=p1XLep7gywfDdfCI


using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour



{
    [SerializeField] GameObject pauseMenu;
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

        AudioListener.volume = 1;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
