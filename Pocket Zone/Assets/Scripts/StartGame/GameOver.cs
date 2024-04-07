using UnityEngine;

public class GameOver : MonoBehaviour,IDeath
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameInterface;

     public void GameOverControll()
    {
        gameInterface.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}