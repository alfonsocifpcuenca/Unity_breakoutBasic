using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*
     * Variable privada para controlar el n�mero de vidas del
     * jugador
     * */
    [SerializeField]
    private int vidas;

    /*
     * Definmos este getter para poder acceder al n� de vidas
     * desde cualquier punto de la aplicaci�n (UI, Consola...)
     * */
    public int Vidas { get { return vidas; } }

    /*
     * Variable privada para controlar el n�mero de puntos del
     * jugador
     * */
    [SerializeField]
    private int puntos;
    
    /*
     * Definimos este getter para poder acceder al n� de puntos
     * desde cualquier punto de la aplicaci�n (UI, Consola...)
     * */
    public int Puntos { get { return puntos; } }

    /*
     * Variable privada para controlar el n�mero de ladrillos
     * rotos que lleva el jugador
     * */
    [SerializeField]
    private int ladrillosRotos;

    /*
     * Definimos este getter para poder acceder al n� de ladrillos
     * rotos desde cualquier punto de la aplicaci�n (UI, Consola...)
     * */
    public int LadrillosRotos { get { return ladrillosRotos; } }

    private List<Type> potenciadoresDisponibles = new List<Type>();

    private void Awake()
    {
        this.potenciadoresDisponibles = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.IsSubclassOf(typeof(Potenciador)))
            .ToList();


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
            .OrderBy(x => UnityEngine.Random.value)
            .Take(10)
            .ToList();

        /*
         * Recorremos la lista de ladrillos con potenciador y le asociamos un 
         * potenciador en particular
         * */
        foreach (GameObject ladrillo in LadrillosConPotenciador)
        {
            var ladrilloScript = ladrillo.GetComponent<Ladrillo>();
            var potenciadorAleatorio = ObtenerPotenciadorAleatorio();
            if (potenciadorAleatorio == null)
                continue;

            var gameObjectTemporal = new GameObject(potenciadorAleatorio.Name);
            gameObjectTemporal.AddComponent(potenciadorAleatorio);

            ladrilloScript.Potenciador = gameObjectTemporal;            
        }
    }

    private Type ObtenerPotenciadorAleatorio()
    {
        if (this.potenciadoresDisponibles.Count == 0)
            return null;

        var tipoAleatorio = this.potenciadoresDisponibles[UnityEngine.Random.Range(0, this.potenciadoresDisponibles.Count)];

        // Instancia el potenciador y devuelve la instancia
        return tipoAleatorio;
    }


    /*
     * M�todo p�blico para restar una vida
     * */
    public void RestarVida()
    {
        this.vidas = this.vidas - 1;
        Debug.Log($"Vidas: {this.vidas}");
    }

    /*
     * M�todo p�blico para aumentar el contador de ladrillos rotos
     * */
    public void RompemosLadrillo()
    {
        this.ladrillosRotos++;
    }

    /*
     * M�todo para aumentar las vidas del jugador que se llamar�
     * cuando coja un Potenciador
     * */
    public void AumentarVida()
    {
        this.vidas++;
    }
}
