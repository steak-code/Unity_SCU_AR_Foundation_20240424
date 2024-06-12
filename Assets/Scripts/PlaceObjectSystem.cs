using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectSystem : MonoBehaviour
{
    [SerializeField, Header("要放置的物件")]
    private GameObject prefabPlaceObject;

    private bool isPlaced;
    private ARRaycastManager arRaycastManager;
    private Vector2 mousePosition;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        PlaceObject();
    }

    private void PlaceObject()
    {
        // 如果有放置物件就跳出
        if (isPlaced) return;
        // 如果按下左鍵 (觸控)
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        { 
            // 獲得滑鼠座標
            mousePosition = Input.mousePosition;
            // 以滑鼠座標發射射線判定是否打到 AR 地板
            if (arRaycastManager.Raycast(mousePosition, hits, TrackableType.Planes)) 
            {
                // 如果還沒有放置物件
                // 有打到 AR 地板就生成 要放置的物件
                Vector3 point = hits[0].pose.position;
                Instantiate(prefabPlaceObject, point, Quaternion.identity);
                // 已經放置物件
                isPlaced = true;
            }
        }
    }
}
