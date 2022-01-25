using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private Transform containerTransform;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private Button removeButton;
    
    
    private Highscores currentHighScores;
    private List<GameObject> currentPanelsList;
    
    private int indexOfSelectedPlayerInfo;
    private bool isSeleckted = false;

    private void Start()
    {
        AddHighScorePlayerInfo("Nickname", 100);
        AddHighScorePlayerInfo("Nickname 1", 50);
        
        SortPlayersInfoByHighScore();
        RefreshPanels();
    }

    void AddHighScorePlayerInfo(string namePLayer, int score)
    {
        PlayerInfo playerInfo = new PlayerInfo(namePLayer, score);
        
        if (currentHighScores == null)
        {
            // Debug.Log("Create HighScore");
            currentHighScores = new Highscores();
            currentHighScores.highScorePlayers = new List<PlayerInfo>();
        }
        
        currentHighScores.highScorePlayers.Add(playerInfo);
    }

    void RefreshPanels()
    {
        if (currentHighScores == null) return;
        DeleteAllCurrentPanels();
        currentPanelsList = new List<GameObject>();
        for (int i = 0; i < currentHighScores.highScorePlayers.Count; i++)
        {
            var pan = Instantiate(panelPrefab, containerTransform);
            var panDemonstrator = pan.GetComponent<PanelInfoDemonstrator>();
            panDemonstrator.SetPlayerInfo(i, currentHighScores.highScorePlayers[i].playerName, currentHighScores.highScorePlayers[i].playerScore);
            var panPressDetector = pan.GetComponent<PanelPressedDetector>();
            panPressDetector.SetManager(this);
            currentPanelsList.Add(pan);
        }
    }

    void DeleteAllCurrentPanels()
    {
        if(currentPanelsList == null) return;
        foreach (var panel in currentPanelsList)
        {
            Destroy(panel.gameObject);
        }
    }
    
    void SortPlayersInfoByHighScore()
    {
        for (int i = 0; i < currentHighScores.highScorePlayers.Count; i++) {
            for (int j = i + 1; j < currentHighScores.highScorePlayers.Count; j++) {
                if (currentHighScores.highScorePlayers[j].playerScore > currentHighScores.highScorePlayers[i].playerScore) {
                    PlayerInfo tmp = currentHighScores.highScorePlayers[i];
                    currentHighScores.highScorePlayers[i] = currentHighScores.highScorePlayers[j];
                    currentHighScores.highScorePlayers[j] = tmp;
                }
            }
        }
    }
    
    public void AddNewPlayerInfo(string namePlayer, int scorePlayer)
    {
        // int score = Random.Range(0, 2000);
        // string name = $"Ololo {score}";
        AddHighScorePlayerInfo(namePlayer, scorePlayer);
        SortPlayersInfoByHighScore();
        RefreshPanels();
    }

    public void UnselectAllPanels()
    {
        if(currentPanelsList == null) return;
        foreach (var panel in currentPanelsList)
        {
            panel.GetComponent<PanelPressedDetector>().Unselect();
        }
        isSeleckted = false;
    }

    public void SelectPanel(int index)
    {
        isSeleckted = true;
        indexOfSelectedPlayerInfo = index;
    }

    public void OnRemoveButton()
    {
        if(!isSeleckted) return;
        Debug.Log(indexOfSelectedPlayerInfo);
        RemoveSelectedPlayerInfo();
        SortPlayersInfoByHighScore();
        RefreshPanels();
    }

    void RemoveSelectedPlayerInfo()
    {
        if (currentHighScores == null)
        {
            // Debug.Log("Create HighScore");
            currentHighScores = new Highscores();
            currentHighScores.highScorePlayers = new List<PlayerInfo>();
        }

        if (currentHighScores.highScorePlayers[indexOfSelectedPlayerInfo] == null)
        {
            Debug.Log("Error: try delete non-existent index");
        }
        Debug.Log(currentHighScores.highScorePlayers.Count);
        currentHighScores.highScorePlayers.RemoveAt(indexOfSelectedPlayerInfo);
        Debug.Log(currentHighScores.highScorePlayers.Count);
    }
}
