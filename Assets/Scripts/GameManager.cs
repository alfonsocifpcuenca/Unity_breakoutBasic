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
        List<GameObject> LadrillosEnEscena = GameObject.FindGameObjectsWithTag("Ladrillo")
            .ToList();

        List<GameObject> LadrillosConPotenciador = LadrillosEnEscena
            .OrderBy(x => Random.value)
            .Take(44)
            .ToList();

        foreach(GameObject ladrillo in LadrillosConPotenciador)
    {
            var ladrilloScript = ladrillo.GetComponent<Ladrillo>();
            //ladrilloScript.Potenciador = new AumentarVida();

            var miGameObject = new GameObject();
            miGameObject.AddComponent<AumentarTamano>();
            ladrilloScript.MiPotenciador = miGameObject;
    }

        Debug.Log($"Hay {LadrillosEnEscena.Count} ladrillos en la escena.");
    /*
     * Método público para restar una vida
     * */
    public void RestarVida()
    {
        this.vidas = this.vidas - 1;
        Debug.Log($"Vidas: {this.vidas}");
    }

    public void RompemosLadrillo()
    /*
     * Método que devolverá si el jugador está muerto (vidas = 0)
     * o si tiene vidas aún
     * */
    public bool EstaMuerto()
    {
        this.ladrillosRotos++;
        if (this.vidas == 0)
            return true;
        else
            return false;
    }

    /*
     * Método público para sumar puntos en el marcador
     * del jugador
     * */
    public void SumarPuntos(int puntos)
    public void AumentarVida()
    {
        /*
         * Sumamos los puntos que nos haya dado el ladrillo roto
         * */
        this.puntos = this.puntos + puntos;

        /*
         * Aumentamos el nº de ladrillos que hemos roto
         * */
        this.ladrillosRotos = this.ladrillosRotos + 1;
        this.vidas++;
    }
}
