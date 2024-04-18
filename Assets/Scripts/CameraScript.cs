using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField]
    private GameObject PLayer;

    private Vector3 targetPosition;

    [SerializeField] 
    private float forward;

    [SerializeField] 
    private float smoothing;
    

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        targetPosition = new Vector3(PLayer.transform.position.x, transform.position.y, transform.position.z);

        if (PLayer.transform.localScale.x == 1)
        {
            targetPosition = new Vector3(targetPosition.x + forward, targetPosition.y, transform.position.z);
        }
        if (PLayer.transform.localScale.x == -1)
        {
            targetPosition = new Vector3(targetPosition.x - forward, targetPosition.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing * Time.deltaTime);
    }
}
