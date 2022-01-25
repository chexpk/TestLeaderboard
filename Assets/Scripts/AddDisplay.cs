using System;
using UnityEngine;
using UnityEngine.UI;

public class AddDisplay : MonoBehaviour
{
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private InputField nameInputField;
    [SerializeField] private InputField scoreInputField;
    [SerializeField] private Button addButton;

    private void Update()
    {
        SetButtonStatus(CheckIsInputEmpty());
    }

    bool CheckIsInputEmpty() 
    {
        string newName = nameInputField.text;
        string newScore = scoreInputField.text;
        if (!string.IsNullOrWhiteSpace(newName) && !string.IsNullOrWhiteSpace(newScore)) return true;
        return false;
    }

    void SetButtonStatus(bool isActive)
    {
        addButton.interactable = isActive;
        // Debug.Log(isActive);
    }

    public void OnAddButton()
    {
        string newName = nameInputField.text;
        int newScore = int.Parse(scoreInputField.text);
        leaderboardManager.AddNewPlayerInfo(newName, newScore);
        
        nameInputField.text = "";
        scoreInputField.text = "";
    }
    
}
