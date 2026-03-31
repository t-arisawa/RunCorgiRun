using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    
    public TMP_Text scoreText;
    public CanvasGroup StartScreenCanvasGroup;

    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);

    }
}
