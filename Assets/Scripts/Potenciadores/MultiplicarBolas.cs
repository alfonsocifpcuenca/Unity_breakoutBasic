using System;
using UnityEngine;

public class MultiplicarBolas : Potenciador
{
    public override void Aplicar()
    {
        try
        {
            /*
                * Buscamos el GameManajer entre los objects de la escena
                * */
            var bola = GameObject.FindGameObjectWithTag("Bola");

            if (bola != null)
            {
                Vector3 posicionBola = bola.transform.position;
                Vector3 direccionBola = bola.GetComponent<Rigidbody2D>().velocity;

                Vector3 nuevaDireccion = new Vector3(direccionBola.x + 1f, direccionBola.y, direccionBola.z).normalized * direccionBola.magnitude;

                GameObject nuevaBola = Instantiate(bola, posicionBola, Quaternion.identity);
                nuevaBola.GetComponent<Rigidbody2D>().velocity = nuevaDireccion;
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
