
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private UpdateScoreInfo scoreViewer;
    
    private Button button;
    private int score = 0;
    private int highScore = 0;

    public int Score => score;
    public int HighScore => highScore;

    private void Awake()
    {
        var widget = GameObject.FindGameObjectWithTag("Buttons");
        button = widget.GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.Click += ResetScore;
        player.GiveScore += AddScore;
    }

    private void OnDisable()
    {
        button.Click -= ResetScore;
        player.GiveScore -= AddScore;
    }

    private void AddScore()
    {
        score += 1;

        if (score > highScore)
        {
            highScore = score;
        }

        scoreViewer.UpdateScore();
    }

    public void ResetScore()
    {
        score = 0;
        scoreViewer.UpdateScore();
    }
}
