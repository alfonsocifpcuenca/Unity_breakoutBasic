using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int vidasDelJugador;

    private int ladrillosRotos;
    private List<GameObject> ladrillosDelNivel = new List<GameObject>();

    private void Awake()
    {
        /*
         * Lo primero que hacemos es contar el nº de ladrillos que hay en 
         * el nivel, para ello buscamos los objetos con el tag 'Ladrillo'
         * que hay
         * */
        this.ladrillosDelNivel = GameObject.FindGameObjectsWithTag("Ladrillo").ToList();
        Debug.Log($"En el Nivel hay {this.ladrillosDelNivel.Count} ladrillos");


        /*
         * Repartimos aleatoriamente los potenciadores, para eso elegimos al azhar
         * 10 ladrillos
         * */
        System.Random random = new System.Random();
        List<GameObject> ladrillosAlAzar = ladrillosDelNivel.OrderBy(x => random.Next()).Take(10).ToList();

        /*
         * Para cada uno de los ladrillos elegidos, asociamos el potenciador correspondiente
         * */
        for (int i = 0; i < ladrillosAlAzar.Count; i++) 
        {
            GameObject miPotenciador = new GameObject();
            miPotenciador.name = $"Potenciador_{i + 1}";
            var ladrilloScript = ladrillosAlAzar[i].GetComponent<Ladrillo>();
            ladrilloScript.Potenciador = miPotenciador;
        }
    }

    public int Vidas { get { return this.vidasDelJugador; } }

    public bool EstaVivo()
    {
        return this.vidasDelJugador > 0;
    }

    public void QuitarVida()
    {
        this.vidasDelJugador = this.vidasDelJugador - 1;
    }

    public void RompemosLadrillo()
    {
        this.ladrillosRotos = this.ladrillosRotos + 1;
    }

    public bool HemosRotoTodosLosLadrillos()
    {
        return (this.ladrillosRotos >= this.ladrillosDelNivel.Count);
    }
}
