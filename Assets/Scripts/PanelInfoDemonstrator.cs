using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelInfoDemonstrator : MonoBehaviour
{
    // [SerializeField] private Text positionPlayer;
    [SerializeField] private TMP_Text positionPlayer;
    // [SerializeField] private Text namePlayer;
    [SerializeField] private TMP_Text namePlayer;
    // [SerializeField] private Text scorePlayer;
    [SerializeField] private TMP_Text scorePlayer;
    
    
    private int indexPositionPlayer;
    
    public void SetPlayerInfo(int position, string name, int score)
    {
        positionPlayer.text = (position + 1).ToString();
        indexPositionPlayer = position;
        namePlayer.text = name;
        scorePlayer.text = score.ToString();
    }

    public int GetPosition()
    {
        return indexPositionPlayer;
    }
}
