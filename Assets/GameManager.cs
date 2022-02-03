using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;  // To avoid multiple ends of levels
    [SerializeField] private GameObject levelCompleteGUI;
    
    // This function is called when level ends
    public void EndGame ()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            // Debug.Log("GAME OVER");
            levelCompleteGUI.SetActive(true);
        }
        
    }

    // This function is called to change scene to next level
    public void ChangeToScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // This function is called when exit button is clicked or menu button is clicked to go to menu scene
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // This function is to change the scene to All Levels scene
    public void GoToAllLevels()
    {
        SceneManager.LoadScene("AllLevels");
    }

    // This function is called to restart the level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // This function is called to change the level to level "levelNumber"
    public void GoToLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}
