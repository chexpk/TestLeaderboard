using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelPressedDetector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color selectedColor;
    [SerializeField] private Image backImagePanel;
    [SerializeField] private Image backImagePanel2;
    
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
            Select();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClick();
        }
    }

    public void SetManager(LeaderboardManager manager)
    {
        leaderboardManager = manager;
    }
    
    public void Unselect()
    {
        backImagePanel.color = defaultColor;
        backImagePanel2.color = defaultColor;
    }
    
    void Select()
    {
        leaderboardManager.UnselectAllPanels();
        backImagePanel.color = selectedColor;
        backImagePanel2.color = selectedColor;
        int indexOfPanel = panelDemonstrator.GetPosition();
        leaderboardManager.SelectPanel(indexOfPanel);
    }

    void RightClick()
    {
        leaderboardManager.UnselectAllPanels();
        int indexOfPanel = panelDemonstrator.GetPosition();
        leaderboardManager.OpenToEditPlayerInfoByIndex(indexOfPanel);
    }
}