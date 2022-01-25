using System;
using UnityEngine;
using UnityEngine.UI;


public class EditDisplay : MonoBehaviour
{
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private InputField nameInputField;
    [SerializeField] private InputField scoreInputField;
    private PlayerInfo editedPlayerInfo;
    
    public void SetPlayerInfoToField(PlayerInfo playerInfo)
    {
        editedPlayerInfo = playerInfo;
        if (editedPlayerInfo == null)
        {
            Debug.Log("Error: null playerInfo got");
            return;
        }
        nameInputField.text = editedPlayerInfo.playerName;
        scoreInputField.text = editedPlayerInfo.playerScore.ToString();
    }

    public void OnEditButton()
    {
        editedPlayerInfo.playerName = nameInputField.text;
        editedPlayerInfo.playerScore = int.Parse(scoreInputField.text);
        leaderboardManager.EditPlayerInfo(editedPlayerInfo);
        
        nameInputField.text = "";
        scoreInputField.text = "";
    }
    
}