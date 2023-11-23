using System;
using UnityEngine;

public class AumentarVida : Potenciador
{
    public override void Aplicar()
    {
        try
        {
            /*
                * Buscamos el GameManajer entre los objects de la escena
                * */
            var gameManager = GameObject.FindGameObjectWithTag("GameManager");

            if (gameManager != null)
            {
                /*
                    * Buscamos el script GameManager entre los componentes del GameObject
                    * GameManager
                    * */
                var gameManagerScript = gameManager.GetComponent<GameManager>();

                /*
                    * Aumentamos la vida del jugador a través del GameManager
                    * */
                gameManagerScript?.AumentarVida();

                /*
                    * Destruimos el objeto y liberamos memoria
                    * */
                Destroy(this.gameObject);
            }

        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
}
