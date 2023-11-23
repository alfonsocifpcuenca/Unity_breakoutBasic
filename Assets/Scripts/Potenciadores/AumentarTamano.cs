using System;
using UnityEngine;

public class AumentarTamano : Potenciador
{
    /// <summary>
    /// Variable para almacenar la pala durante todo el script
    /// </summary>
    GameObject pala;
    

    public override void Aplicar()
    {
        try
        {
            /*
             * Buscamos la pala en la escena y aumentamos su tamaño
             * */
            pala = GameObject.FindGameObjectWithTag("Pala");

            if (pala != null)
            {
                /*
                 * Multiplicamos x2 la escala de la pala en el eje X para aumentar 
                 * su tamaño, y aplicamos Mathf.Calmp para que nunca supere 4f
                 * */
                pala.transform.localScale = new Vector3(Mathf.Clamp(pala.transform.localScale.x * 2, 2f, 4f), pala.transform.localScale.y, pala.transform.localScale.z);

                /*
                 * Destruimos el GameObject a los 5 segundos (5f) para invocar el evento
                 * OnDestroy a plicar la lógica necesaria
                 * */
                Destroy(this, 5f);
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    private void OnDestroy()
    {
        if (pala != null)
        {
            /*
             * Dejamos la pala con el tamaño inicial, si el jugador coge varios
             * potenciadores de este tipo no afecta al juego
             * */
            pala.transform.localScale = new Vector3(2f, 0.25f, 0f);
        }
    }
}
