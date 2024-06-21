using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.LogError("Slider component is not found on " + gameObject.name);
        }
    }

    public void CambiarVidaMaxima(int vidaMaxima)
    {
        if (slider != null)
        {
            slider.maxValue = vidaMaxima;
        }
        else
        {
            Debug.LogError("Slider is null when trying to set max value.");
        }
    }

    public void CambiarVidaActual(int cantidadVida)
    {
        if (slider != null)
        {
            slider.value = cantidadVida;
        }
        else
        {
            Debug.LogError("Slider is null when trying to set value.");
        }
    }

    public void InicializarBarraDeVida(int cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
