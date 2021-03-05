using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isStarted = false;
    private bool isNotStarted = false;

    private void Update()
    {
        if (!isNotStarted && Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            isNotStarted = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        GameManager.isStarted = false;
    }
}
