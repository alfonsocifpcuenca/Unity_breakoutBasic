using UnityEngine;
using UnityEngine.UI;

public class UILadrillos : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private Text cuadroDeTexto;

    private void Start()
    {
        this.cuadroDeTexto = this.gameObject.GetComponent<Text>();
    }
}
