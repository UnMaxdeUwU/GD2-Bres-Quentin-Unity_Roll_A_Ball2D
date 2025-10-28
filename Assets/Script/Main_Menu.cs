using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{   
    public string levelToLoad;

    public GameObject setting;
    
    
    
    
    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        setting.SetActive(true);
    }

    public void CloseSettings()
    {
        setting.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
