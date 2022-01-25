using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelPressedDetector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Image backImagePanel;
    
    private LeaderboardManager leaderboardManager;
    private Color defaultColor;
    private PanelInfoDemonstrator panelDemonstrator;

    private void Awake()
    {
        defaultColor = backImagePanel.color;
        panelDemonstrator = GetComponent<PanelInfoDemonstrator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // onLeftClick.Invoke();
            Select();
            Debug.Log( "Left was clicked");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            // onRightClick.Invoke();
            Debug.Log( "Right was clicked");
        }
    }

    public void SetManager(LeaderboardManager manager)
    {
        leaderboardManager = manager;
    }
    
    void Select()
    {
        leaderboardManager.UnselectAllPanels();
        backImagePanel.color = selectedColor;
        int indexOfPanel = panelDemonstrator.GetPosition();
        leaderboardManager.SelectPanel(indexOfPanel);
        //leaderboardManager.SelectPanel(int index)?
    }

    public void Unselect()
    {
        backImagePanel.color = defaultColor;
    }
}