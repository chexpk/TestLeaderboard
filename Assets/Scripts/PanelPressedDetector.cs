using UnityEngine;
using UnityEngine.EventSystems;

public class PanelPressedDetector : MonoBehaviour, IPointerClickHandler
{
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
        // Debug.Log( "Ololo was clicked");
    }
}