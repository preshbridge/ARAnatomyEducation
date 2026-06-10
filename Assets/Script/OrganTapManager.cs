using UnityEngine;
using UnityEngine.UI;

public class OrganTapManager : MonoBehaviour
{
    public GameObject infoPanel;

    public Text organTitle;
    public Text organDescription;

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        Ray ray = Camera.main.ScreenPointToRay(touch.position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            OrganInfo info = hit.collider.GetComponent<OrganInfo>();

            if (info != null)
            {
                infoPanel.SetActive(true);

                organTitle.text = info.organName;
                organDescription.text = info.description;
            }
        }
    }
}