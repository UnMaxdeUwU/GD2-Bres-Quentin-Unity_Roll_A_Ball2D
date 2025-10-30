using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public LevelData[] levelData;

    public int currentlevel = 0;
    private bool finished = false;

    public void NextLevel()
    {
        if (currentlevel < levelData.Length)
        {   
            Debug.Log(levelData[currentlevel].levelTitle);
            SceneManager.LoadScene(levelData[currentlevel].sceneName);
            currentlevel++;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.GetComponent<Main_Player_Mouvement>() != null)
        {
            Debug.Log("finshed = true");
            finished = true;
        }

    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Backspace))
        {
            if (finished)
            {
                Debug.Log("fini");
                NextLevel();
            }

        }

    }


}
