using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelInfoDemonstrator : MonoBehaviour
{
    [SerializeField] private Text positionPlayer;
    [SerializeField] private Text namePlayer;
    [SerializeField] private Text scorePlayer;


    public void SetPlayerInfo(int position, string name, int score)
    {
        positionPlayer.text = position.ToString();
        namePlayer.text = name;
        scorePlayer.text = score.ToString();
    }
    
    public virtual void OnPointerClick()
    {
        Debug.Log(namePlayer.text + " was clicked");
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }
}
