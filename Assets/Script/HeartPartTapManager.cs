using UnityEngine;
using UnityEngine.UI;

public class HeartPartTapManager : MonoBehaviour
{
    [Header("UI REFERENCES")]
    public GameObject infoPanel;
    public Text organTitle;
    public Text descriptionText;

    [Header("AR CAMERA")]
    public Camera arCamera;

    void Start()
    {
        // Hide panel at start
        if (infoPanel != null)
            infoPanel.SetActive(false);

        // Auto-assign main camera if not set
        if (arCamera == null)
            arCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        Ray ray = arCamera.ScreenPointToRay(touch.position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            HeartPartInfo partInfo = hit.collider.GetComponent<HeartPartInfo>();

            if (partInfo != null)
            {
                ShowInfo(partInfo.partName, partInfo.description);
            }
        }
    }

    void ShowInfo(string title, string description)
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);

        if (organTitle != null)
            organTitle.text = title;

        if (descriptionText != null)
            descriptionText.text = description;
    }

    public void HideInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}