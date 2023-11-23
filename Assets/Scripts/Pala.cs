using UnityEngine;

public class Pala : MonoBehaviour
{

    [SerializeField]
    private int constanteVelocidad;
    [SerializeField]
    private float limiteIzquierda;
    [SerializeField]
    private float limiteDerecha;

    [SerializeField]
    private GameManager gameManager;

    void Update()
    {
        MovimientoPala();
    }

    private void MovimientoPala()
    {
        /*
         * Vamos a obtener la dirección de movimiento, con Input.GetAxisRaw obtendre
         * -1 si se está pulsando la flecha izquierda
         * 0 si no se está pulsando nada
         * 1 si se está pulsando la flecha derecha
         * */
        var direccionMovimiento = Input.GetAxisRaw("Horizontal");

        /*
         * Vamos a calcular la nueva coordenada X de posición de la pala en función de lo
         * que hayamos pulsado, la moveremos a la derecha (direccionMovimiento = 1)
         * o a la izquierda (direccionMovimiento = -1)
         * */
        Vector2 posicionPala = transform.position;
        posicionPala.x = Mathf.Clamp(posicionPala.x + (direccionMovimiento * Time.deltaTime * constanteVelocidad), this.limiteIzquierda, this.limiteDerecha);

        /*
         * Asociamos la nueva posicion (posicionPala) a nuestro componente
         * transform del gameobject
         * */
        transform.position = posicionPala;
    }
}
