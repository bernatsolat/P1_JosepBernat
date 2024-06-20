using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform player; // Cambiado a Transform para acceder a todas las coordenadas

    [SerializeField]
    private float smoothing;

    private void LateUpdate()
    {
        // Actualiza la posición de la cámara según las coordenadas del jugador (X e Y)
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y+0.5f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
