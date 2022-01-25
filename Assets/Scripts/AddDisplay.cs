using System;
using UnityEngine;
using UnityEngine.UI;

public class AddDisplay : MonoBehaviour
{
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private InputField nameInputField;
    [SerializeField] private InputField scoreInputField;
    
    public void OnAddButton()
    {
        string newName = nameInputField.text;
        int newScore = int.Parse(scoreInputField.text);
        leaderboardManager.AddNewPlayerInfo(newName, newScore);
        
        nameInputField.text = "";
        scoreInputField.text = "";
    }
}
