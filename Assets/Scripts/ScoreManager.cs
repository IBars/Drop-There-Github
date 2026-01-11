using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int player1Score;
    public int player2Score;

    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    void Awake()
    {
        instance = this;
        UpdateUI();
    }

    public void AddScore(string colorTag)
    {
        if (colorTag == "Red")
            player1Score += 500;
        else if (colorTag == "Yellow")
            player2Score += 500;

        UpdateUI();
    }

    void UpdateUI()
    {
        player1Text.text = "P1: " + player1Score;
        player2Text.text = "P2: " + player2Score;
    }
}
