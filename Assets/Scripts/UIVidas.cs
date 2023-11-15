using UnityEngine;
using UnityEngine.UI;

public class UIVidas : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private Text cuadroDeTexto;

    private void Start()
    {
        this.cuadroDeTexto = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        this.cuadroDeTexto.text = $"Vidas: {this.gameManager.Vidas}";
    }
}
