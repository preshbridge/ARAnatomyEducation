using UnityEngine;

public class ClosePanel : MonoBehaviour
{
    public GameObject infoPanel;

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
    }
}