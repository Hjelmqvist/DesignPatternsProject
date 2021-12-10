using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    [SerializeField] GameObject _panel;

    public void OpenPanel()
    {
        _panel.SetActive( true );
    }

    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
}