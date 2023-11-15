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
     * Método que devolverá si el jugador está muerto (vidas = 0)
     * o si tiene vidas aún
     * */
    public bool EstaMuerto()
    {
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
    {
        /*
         * Sumamos los puntos que nos haya dado el ladrillo roto
         * */
        this.puntos = this.puntos + puntos;

        /*
         * Aumentamos el nº de ladrillos que hemos roto
         * */
        this.ladrillosRotos = this.ladrillosRotos + 1;
    }
}
