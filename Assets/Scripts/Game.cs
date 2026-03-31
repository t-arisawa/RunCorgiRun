using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    
    public void OnStartButtonClicked()
    {
        Ui.HideStartScreen();
        // start game
    }
}
