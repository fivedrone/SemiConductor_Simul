using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{
    // 버그 발생... 나중에 건드릴것.
    // public GameObject markerPrefab; //마커는 화살표. 화살표로 목표 지점 가리키기. 퀘스트 매니저가 마커를 생성하고 삭제할 것.
    // public GameObject _markerInstance;
    // public GameObject Player;
    //
    // public void MakeMarker(Vector3 targetPosition)
    // {
    //     Debug.Log("MakeMarker");
    //     RaycastHit hit;
    //     if (Physics.Raycast(Player.transform.position, (targetPosition - Player.transform.position).normalized, out hit))
    //     {
    //         _markerInstance = Instantiate(markerPrefab, hit.collider.transform.position, Quaternion.LookRotation(targetPosition  - Player.transform.position));
    //         Debug.Log("MakeMarker Finish");
    //     }
    // }
    //
    // public void DestroyMarker()
    // {
    //     if (_markerInstance)
    //     {
    //         Destroy(_markerInstance);
    //     }
    // }
    //
    // public void UpdateMarker(Vector3 targetPosition)
    // {
    //     RaycastHit hit;
    //     if (Physics.Raycast(transform.position, targetPosition - transform.position, out hit))
    //     {
    //         Debug.DrawRay(Player.transform.position, (targetPosition - Player.transform.position) * hit.distance, Color.red, 5.0f);
    //         _markerInstance.transform.position = hit.collider.transform.position;
    //         Debug.Log(hit.collider.transform.position);
    //     }
    // }
}
