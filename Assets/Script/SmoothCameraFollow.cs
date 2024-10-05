using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float camSpeed;
    [SerializeField] Camera cam;

    [Header("Camera Bound Variables")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    [Header("Camera Zoom Variable")]
    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;
    [SerializeField] float zoomFactor = 0.5f;

    void Update()
    {
        Vector3 targetPosition = Vector3.Lerp(transform.position, player.position, camSpeed * Time.deltaTime);

        float moveX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float moveY = Mathf.Clamp(targetPosition.y, minY, maxY);
        transform.position = new Vector3(moveX, moveY, transform.position.z);

        cameraZoomOut();
    }

    public void cameraZoomOut()
    {
        float playerSize = player.localScale.x;
        float newZoom = Mathf.Lerp(minZoom, maxZoom, Mathf.Log(playerSize - 1) * zoomFactor);
        Debug.Log(newZoom);
        cam.orthographicSize = Mathf.Clamp(newZoom, minZoom, maxZoom);
    }

}
