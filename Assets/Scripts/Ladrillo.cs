using UnityEngine;

public class Ladrillo : MonoBehaviour
{
    [SerializeField]
    public int GolpesQueAguanta;

    private int puntosQueDa;

    private void Start()
    {
        this.puntosQueDa = 25 * this.GolpesQueAguanta;
    }

    public int PuntosQueDa { get { return this.puntosQueDa; } }
}
