using UnityEngine;

public class Ladrillo : MonoBehaviour
{
    /*
     * Indicamos los golpes que aguante el ladrillo antes de romperse
     * */
    [SerializeField]
    public int GolpesQueAguanta;

    /*
     * GameObject con el potenciador correspondiente, incialmente será null
     * y será el GameManager el encargado de establecer si un ladrillo tiene
     * o no potenciador
     * */
    public GameObject Potenciador;
}
