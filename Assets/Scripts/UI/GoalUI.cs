using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GoalUI : MonoBehaviour
{
    [SerializeField] GameObject _finishPanel;
    [SerializeField] TextMeshProUGUI _scoreText;

    public void Finish(Door.ScoreArgs score)
    {
        _scoreText.text = $"Your score is {score.Score} out of {score.MaxScore}!";
        _finishPanel.SetActive( true );
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
}