using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string m_SceneNameToLoad = "Game";

    public void PlayPressed()
    {
        SceneManager.LoadScene(m_SceneNameToLoad);
    }
}