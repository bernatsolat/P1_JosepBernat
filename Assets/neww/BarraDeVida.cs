using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class BarraDeVida : MonoBehaviour
{

    private UnityEngine.UI.Slider slider;

    private void Start()
    {
        slider = GetComponent<UnityEngine.UI.Slider>();
    }

    public void CambiarVidaMaxima(float vidaMaxima) {
        slider.maxValue = vidaMaxima;
    }
    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }
        
            
        
        public void InicializarBarraDeVida(float cantidadVida)
        {
            CambiarVidaActual(cantidadVida);
            CambiarVidaMaxima(cantidadVida);
    
        }
}