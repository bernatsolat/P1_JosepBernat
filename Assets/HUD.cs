using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas; // Aseg�rate de arrastrar y soltar las im�genes de vida en este array desde el Inspector

    public void DesactivarVida(int indice)
    {
        if (indice >= 0 && indice < vidas.Length)
        {
            vidas[indice].SetActive(false);
        }
    }

    public void ActivarVida(int indice)
    {
        if (indice >= 0 && indice < vidas.Length)
        {
            vidas[indice].SetActive(true);
        }
    }
}
