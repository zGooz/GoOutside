
using UnityEngine;
using TMPro;

public class UpdateScoreInfo : MonoBehaviour
{
    [SerializeField]
    private ScoreContainer scoreBox;
    private TMP_Text textField;

    private void Awake()
    {
        textField = GetComponent<TMP_Text>();
    }

    public void UpdateScore()
    {
        textField.text = "Score : " + scoreBox.Score + 
                         "\nHigh score : " + scoreBox.HighScore;
    }
}
