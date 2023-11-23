using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int vidas;

    public int Vidas { get { return this.vidas; } }

    private int ladrillosRotos;

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
    }

    public void RompemosLadrillo()
    {
        this.ladrillosRotos++;
    }

    public void AumentarVida()
    {
        this.vidas++;
    }
}
