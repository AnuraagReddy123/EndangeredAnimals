using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    [SerializeField] private GameObject levelCompleteGUI;
    public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            // Debug.Log("GAME OVER");
            levelCompleteGUI.SetActive(true);
        }
        
    }

    public void ChangeToScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToAllLevels()
    {
        SceneManager.LoadScene("AllLevels");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}
