using UnityEngine;
using UnityEngine.UI;

public class InteractableButton : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private InputField scoreInputField;
    [SerializeField] private Button currentButton;
    
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
        currentButton.interactable = isActive;
    }
}