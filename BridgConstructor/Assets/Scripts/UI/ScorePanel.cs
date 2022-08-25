using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{

    [SerializeField]private TMP_Text _scoreText;
    [SerializeField]private GameObject _scorePanel;

    private void Awake() 
    {
        Robot.UpdateScore += updateScorePanel;
        Grounder.NotGrounder += hideScorePanel;
    }   

    private void OnDestroy() 
    {
        Robot.UpdateScore -= updateScorePanel;
        Grounder.NotGrounder -= hideScorePanel;
    }

    private void updateScorePanel()
    {
        _scoreText.text = Robot.Score.ToString();
    }

    private void hideScorePanel()
    {
        _scorePanel.SetActive(false);
    }
}
