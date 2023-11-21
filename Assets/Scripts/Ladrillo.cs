using UnityEngine;

public class Ladrillo : MonoBehaviour
{
    [SerializeField]
    public int GolpesQueAguanta;

    private int puntosQueDa;

    public int PuntosQueDa { get { return this.puntosQueDa; } }

    public GameObject Potenciador;

    private void Start()
    {
        this.puntosQueDa = 25 * this.GolpesQueAguanta;
    }
}
