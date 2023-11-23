using System;
using UnityEngine;

public class AumentarVida : Potenciador
{
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

    private void Awake()
    {
        Debug.Log("Cosas raras");
    }
}
