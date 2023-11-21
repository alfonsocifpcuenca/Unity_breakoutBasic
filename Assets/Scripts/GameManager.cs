using System.Collections.Generic;
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

    private List<GameObject> ladrillosEnPantalla = new List<GameObject>();

    [SerializeField]
    private List<GameObject> potenciadores;

    private void Awake()
    {
        ladrillosEnPantalla = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ladrillo"));
        Debug.Log($"Hay {this.ladrillosEnPantalla.Count} ladrillos en la pantalla");

        // TODO Repartimos los potenciadores aleatoriamente de la lista de potenciadores
        ladrillosEnPantalla[0].GetComponent<Ladrillo>().Potenciador = this.potenciadores[0];
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
     * M�todo que devolver� si el jugador est� muerto (vidas = 0)
     * o si tiene vidas a�n
     * */
    public bool EstaMuerto()
    {
        if (this.vidas == 0)
            return true;
        else
            return false;
    }

    /*
     * M�todo p�blico para sumar puntos en el marcador
     * del jugador
     * */
    public void SumarPuntos(int puntos)
    {
        /*
         * Sumamos los puntos que nos haya dado el ladrillo roto
         * */
        this.puntos = this.puntos + puntos;

        /*
         * Aumentamos el n� de ladrillos que hemos roto
         * */
        this.ladrillosRotos = this.ladrillosRotos + 1;
    }
}
