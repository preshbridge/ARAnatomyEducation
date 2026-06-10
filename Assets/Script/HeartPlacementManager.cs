using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class HeartPlacementManager : MonoBehaviour
{
    public GameObject heartPrefab;

    private ARRaycastManager raycastManager;
    private GameObject spawnedHeart;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase != TouchPhase.Began)
            return;

        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (spawnedHeart == null)
            {
                Debug.Log("Heart Spawned!");

                spawnedHeart = Instantiate(
                    heartPrefab,
                    hitPose.position + new Vector3(0f, 0.3f, 0f),
                    Quaternion.identity
                );

                spawnedHeart.transform.localScale = new Vector3(5f, 5f, 5f);
            }
        }
    }
}