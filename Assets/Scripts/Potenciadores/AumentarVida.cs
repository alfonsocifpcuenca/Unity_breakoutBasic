using System;
using UnityEngine;

public class AumentarVida : Potenciador
{

    public AumentarVida() {
        Debug.Log("Instanciamos aumentarvida");
    }
    
    public override void Aplicar()
    {
        try
        {
            var gameManager = GameObject.FindGameObjectWithTag("GameManager");
            gameManager.GetComponent<GameManager>().AumentarVida();
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
