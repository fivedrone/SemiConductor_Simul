using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    public Camera getCamera;

    private RaycastHit hit;

    void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            if (Physics.Raycast(getCamera.transform.position, getCamera.transform.forward, out hit, 1000))
            {
                GameObject objectName = hit.collider.gameObject;

                Debug.Log(objectName.name);
                Debug.DrawRay(getCamera.transform.position, getCamera.transform.forward * hit.distance, Color.red, 10.0f);
            }
        }
    }
}
