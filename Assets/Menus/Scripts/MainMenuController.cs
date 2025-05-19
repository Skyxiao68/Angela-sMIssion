//Make Your MAIN MENU Quickly! | Unity UI Tutorial For Beginners
//ReHope Games 
//Version 5 
// 14 April 2025
// https://youtu.be/DX7HyN7oJjE?si=p1XLep7gywfDdfCI

using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1;
    }
    public void howToPlay()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void backToMainMenu()
    {
        SceneManager.LoadSceneAsync("Main menu"); //Dont know why the number 0 doesnt work but making a string works too 
    }

    public void Story()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("RageQuit");
    }



}
