using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    public GameObject markerPrefab; //마커는 화살표. 화살표로 목표 지점 가리키기. 퀘스트 매니저가 마커를 생성하고 삭제할 것.
    
    public GameObject _markerInstance;
    public void MakeMarker(Vector3 targetPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.position - targetPosition, out hit))
        {
            _markerInstance = Instantiate(markerPrefab, hit.point, Quaternion.LookRotation(transform.position - targetPosition));
        }
    }
    
    public void DestroyMarker()
    {
        if (_markerInstance)
        {
            Destroy(_markerInstance);
        }
    }

    public void UpdateMarker(Vector3 targetPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, targetPosition - transform.position, out hit))
        {
            _markerInstance.transform.position = hit.point;
        }
    }
}
