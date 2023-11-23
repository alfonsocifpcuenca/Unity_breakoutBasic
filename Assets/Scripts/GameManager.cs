using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * Variable privada para controlar el número de vidas del
     * jugador
     * */
    [SerializeField]
    private int vidas;

    /*
     * Definmos este getter para poder acceder al nº de vidas
     * desde cualquier punto de la aplicación (UI, Consola...)
     * */
    public int Vidas { get { return vidas; } }

    /*
     * Variable privada para controlar el número de puntos del
     * jugador
     * */
    [SerializeField]
    private int puntos;
    
    /*
     * Definimos este getter para poder acceder al nº de puntos
     * desde cualquier punto de la aplicación (UI, Consola...)
     * */
    public int Puntos { get { return puntos; } }

    /*
     * Variable privada para controlar el número de ladrillos
     * rotos que lleva el jugador
     * */
    [SerializeField]
    private int ladrillosRotos;

    /*
     * Definimos este getter para poder acceder al nº de ladrillos
     * rotos desde cualquier punto de la aplicación (UI, Consola...)
     * */
    public int LadrillosRotos { get { return ladrillosRotos; } }

    private void Awake()
    {
        /*
         * Obtenemos los ladrillos que hay en la escena y los metemos en
         * una lista de GameObjects
         * */
        List<GameObject> LadrillosEnEscena = GameObject.FindGameObjectsWithTag("Ladrillo")
            .ToList();

        /*
         * De la lista de ladrillos, cogemos aleatoriamente (OrderBy...Random.value)
         * 10 para asociarles un potenciador a esos ladrillos
         * */
        List<GameObject> LadrillosConPotenciador = LadrillosEnEscena
            .OrderBy(x => Random.value)
            .Take(10)
            .ToList();

        /*
         * Recorremos la lista de ladrillos con potenciador y le asociamos un 
         * potenciador en particular
         * */
        foreach (GameObject ladrillo in LadrillosConPotenciador)
        {
            var ladrilloScript = ladrillo.GetComponent<Ladrillo>();
            var gameObjectTemporal = new GameObject();
            gameObjectTemporal.AddComponent<AumentarTamano>();
            ladrilloScript.Potenciador = gameObjectTemporal;
        }
    }

    /*
     * Método público para restar una vida
     * */
    public void RestarVida()
    {
        this.vidas = this.vidas - 1;
        Debug.Log($"Vidas: {this.vidas}");
    }

    /*
     * Método público para aumentar el contador de ladrillos rotos
     * */
    public void RompemosLadrillo()
    {
        this.ladrillosRotos++;
    }

    /*
     * Método para aumentar las vidas del jugador que se llamará
     * cuando coja un Potenciador
     * */
    public void AumentarVida()
    {
        this.vidas++;
    }
}
