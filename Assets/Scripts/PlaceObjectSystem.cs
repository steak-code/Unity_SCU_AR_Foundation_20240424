using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectSystem : MonoBehaviour
{
    [SerializeField, Header("�n��m������")]
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
        // �p�G����m����N���X
        if (isPlaced) return;
        // �p�G���U���� (Ĳ��)
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        { 
            // ��o�ƹ��y��
            mousePosition = Input.mousePosition;
            // �H�ƹ��y�еo�g�g�u�P�w�O�_���� AR �a�O
            if (arRaycastManager.Raycast(mousePosition, hits, TrackableType.Planes)) 
            {
                // �p�G�٨S����m����
                // ������ AR �a�O�N�ͦ� �n��m������
                Vector3 point = hits[0].pose.position;
                Instantiate(prefabPlaceObject, point, Quaternion.identity);
                // �w�g��m����
                isPlaced = true;
            }
        }
    }
}
