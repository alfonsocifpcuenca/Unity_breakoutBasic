using UnityEngine;
using UnityEngine.UI;

public class UIPuntos : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private Text cuadroDeTexto;

    private void Start()
    {
        this.cuadroDeTexto = this.gameObject.GetComponent<Text>();
    }
}
