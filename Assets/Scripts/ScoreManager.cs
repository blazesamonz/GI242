using UnityEngine;
using Manager;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    private GameManager gameManager;

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.gameManager.OnRestarted += OnRestarted;
        HideScore(false);
        SetScore(0);
    }

    public void SetScore(int score) 
    {
        scoreText.text = $"Score {score}";
    }

    private void OnRestarted() 
    {
        gameManager.OnRestarted -= OnRestarted;
        HideScore(true);
        SetScore(0);   
    }

    private void HideScore(bool hide) 
    {
        scoreText.transform.gameObject.SetActive(!hide);
    }
}
