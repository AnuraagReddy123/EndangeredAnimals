using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void GoToLevel(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}
