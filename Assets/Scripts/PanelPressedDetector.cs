using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelPressedDetector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color selectedColor;
    
    private LeaderboardManager leaderboardManager;
    private Color defaultColor;

    private void Awake()
    {
        // gameObject.GetComponent<Image>()
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // onLeftClick.Invoke();
            Debug.Log( "Left was clicked");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // onRightClick.Invoke();
            Debug.Log( "Right was clicked");
        }
    }
}