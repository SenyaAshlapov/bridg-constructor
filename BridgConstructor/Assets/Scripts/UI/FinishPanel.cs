using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishPanel : MonoBehaviour
{
    [SerializeField]private TMP_Text _scoreText;
    [SerializeField]private GameObject _finishPanel;

    private void Awake() 
    {
        Robot.FinishLevel += showFinishPanel;
    }   

    private void OnDestroy() 
    {
        Robot.FinishLevel -= showFinishPanel;
    }

    private void showFinishPanel()
    {
        _finishPanel.SetActive(true);
        _scoreText.text = Robot.Score.ToString();
    }


    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
