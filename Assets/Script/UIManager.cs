using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject instructionPanel;
    public GameObject infoPanel;

    public void OpenInstructions()
    {
        homePanel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void BackHome()
    {
        instructionPanel.SetActive(false);
        infoPanel.SetActive(false);
        homePanel.SetActive(true);
    }

    public void StartAR()
    {
        homePanel.SetActive(false);
    }

    public void Exit()
    {
        homePanel.SetActive(false);
    }

    public void closeinfopanel()
    {
        infoPanel.SetActive(false);
        
    }
}