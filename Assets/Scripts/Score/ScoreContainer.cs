
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private Button button;
    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        var widget = GameObject.FindGameObjectWithTag("Buttons");
        button = widget.GetComponent<Button>();
    }

    private void OnEnable()
    {
        player.GiveScore += AddScore;
        button.Click += ResetAll;
    }

    private void OnDisable()
    {
        player.GiveScore -= AddScore;
        button.Click -= ResetAll;
    }

    private void AddScore()
    {
        score += 1;

        if (score > highScore)
        {
            highScore = score;
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    private void ResetAll()
    {
        score = 0;
        highScore = 0;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
