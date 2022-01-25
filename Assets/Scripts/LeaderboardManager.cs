using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private Transform containerTransform;
    [SerializeField] private GameObject panelPrefab;
    private Highscores currentHighScores;
    private List<GameObject> currentPanelsList;

    private void Start()
    {
        AddHighScorePlayerInfo("Ololo1", 0001);
        AddHighScorePlayerInfo("Ololo2", 0002);
        AddHighScorePlayerInfo("Ololo3", 0003);
        AddHighScorePlayerInfo("Ololo4", 1004);
        AddHighScorePlayerInfo("Ololo5", 1005);
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
            panDemonstrator.SetPlayerInfo(i+1, currentHighScores.highScorePlayers[i].playerName, currentHighScores.highScorePlayers[i].playerScore);
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

    public void AddNewPlayerInfo()
    {
        int score = Random.Range(0, 2000);
        string name = $"Ololo {score}";
        AddHighScorePlayerInfo(name, score);
        SortPlayersInfoByHighScore();
        RefreshPanels();
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
}
