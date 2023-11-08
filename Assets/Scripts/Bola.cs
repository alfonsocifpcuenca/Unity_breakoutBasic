using UnityEngine;

public class Bola : MonoBehaviour
{
    [SerializeField]
    private GameObject pala;
    [SerializeField] 
    private Vector2 velocidadInicial;

    private Rigidbody2D bolaRigidBody;
    private bool estaEnMovimiento = false;

    private float multiplicadorVelocidad = 1.05f;

    private void Start()
    {
        /*
         * Establecemos el rigid body de la bola
         * */
        bolaRigidBody = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        this.LanzamientoBola();
    }

    private void LanzamientoBola()
    {
        /*
         * Si pulsamos el espacio y la bola está parada (estaEnMovimiento = false)
         * entonces lanzamos la bola con la velocidad inicial
         * */
        if (Input.GetKeyDown(KeyCode.Space) && estaEnMovimiento == false)
        {
            /*
             * Quitamos la bola como hija de la pala para que pueda 
             * despegarse de ella
             * */
            transform.parent = null;

            /*
             * Asociamos al RigidBody de la bola una velocidad inicial
             * para que salga disparada
             * */
            bolaRigidBody.velocity = velocidadInicial;

            /*
             * Indicamos al script que la bola está en movimiento
             * estaEnMovimiento = true;
             * */
            this.estaEnMovimiento = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
         * Gestionamos la lógica al chocar contra la pala
         * */
        ChocamosContraLaPala(collision);

        /*
         * Gestionamos la lógica al chocar contra un ladrillo
         * */
        ChocamosContraLadrillo(collision);
    }

    private void ChocamosContraLaPala(Collision2D collision)
    {
        /*
         * Comprobamos si realmente estamos chocando con la pala, y si
         * es así modificaremos su rebote
         * */
        if (collision.transform.CompareTag("Pala"))
        {
            /*
             * Calculamos el punto donde la bola ha chocado con la pala, y normalizamos
             * ese valor obteniendo finalmente un valor entre 0 y 1, siendo:
             * 0 - Extremo izquierdo de la pala
             * 1 - Extremo derecho de la pala
             * */
            float anchoPala = collision.transform.localScale.x;
            Vector2 posicionDeChoque = transform.position - collision.transform.position;
            float posicionDeChoqueNormalizada = Mathf.Clamp((posicionDeChoque.x + (anchoPala / 2)) / anchoPala, 0, 1);

            /*
             * En función de donde haya chocado (posicionDeChoqueNormalizada) obtenemos
             * un angulo para aplicar a la bola, teniendo en cuenta que cuando el punto
             * es 0 (extremo izquierdo) enviaremos la bola hacia la izquierda y cuando 
             * es 1 (extremo derecho) enviaremos la bola hacia la derecha.
             * Para esto usamos Mathf.Lerp que nos interpolará entre los ángulos 150º y 30º
             * en función de posicionDeChoqueNormalizada, devolviendo 150 para una
             * posición de 0 y 30 para una posición de 1
             * */
            float anguloDeReboteEnGrados = Mathf.Lerp(150, 30, posicionDeChoqueNormalizada);
            
            /*
             * Calculamos un vector con la direccion indicada por el anguloDeReboteEnGrados, 
             * para eso con Quaternion obtendremos la dirección, que multiplicaremos por un
             * Vector2.right (1, 0) y por una magnitud (10) para afectar mas o menos al rebote
             * */
            var direccionDeReboteQuaternion = Quaternion.AngleAxis(anguloDeReboteEnGrados, Vector3.forward);
            var direccionDeRebote = direccionDeReboteQuaternion * Vector2.right * 4;

            /*
             * Calculamos la nueva velocidad de la bola sumando la velocidad actual con 
             * el rebote causado por la pala.
             * */
            var nuevaVelocidad = bolaRigidBody.velocity + new Vector2(direccionDeRebote.x, direccionDeRebote.y);

            /*
             * Para que la magnitud de la velocidad no varie (la velocidad unicamente
             * cambie de dirección) normalizamos el vector actual, es decir lo reducimos 
             * a un vector de magnitud 1 y lo multiplicamos por la magnitud que lleva la
             * pelota actualmente
             * */
            var nuevaVelocidadNormalizada = nuevaVelocidad.normalized;
            var nuevaVelocidadCalculada = nuevaVelocidadNormalizada * bolaRigidBody.velocity.magnitude;

            /* 
             * Asociamos la nueva velocidad calculada a la bola
             * */
            bolaRigidBody.velocity = nuevaVelocidadCalculada;
        }
    }

    private void ChocamosContraLadrillo(Collision2D collision)
    {
        /*
         * Comprobamos si realmente estamos chocando con un ladrillo, y si
         * es así comprobaremos su vida
         * */
        if (collision.transform.CompareTag("Ladrillo"))
        {
            /*
             * Accedemos al componente Ladrillo.cs del GameObject Ladrillo (collision.transform)
             * */
            var ladrilloScript = collision.transform.GetComponent<Ladrillo>();

            /*
             * Restamos 1 a la variables GolpesQueAguanta
             * */
            ladrilloScript.GolpesQueAguanta = ladrilloScript.GolpesQueAguanta - 1;

            /*
             * Comprobamos si GolpesQueAguanta son 0 o menos (por si acaso) y
             * si es así, destruimos el GameObject del ladrillo
             * */
            if (ladrilloScript.GolpesQueAguanta <= 0)
            {
                Destroy(collision.gameObject);

                /*
                 * Si hemos roto el ladrillo aumentamos la velocidad de la bola
                 * multiplicando su velocidad actual por un incremento del 2%, es decir
                 * por cada ladrillo la bola irá un 2% más rápido
                 * */
                this.bolaRigidBody.velocity = this.bolaRigidBody.velocity * 1.02f;

                /* 
                 * Para evitar que la bola coja mucha velocidad podemos limitar su velocidad con 
                 * Vector2.Cla
                 * */
                this.bolaRigidBody.velocity = Vector2.ClampMagnitude(this.bolaRigidBody.velocity, 10f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ZonaMuerte"))
        {
            Debug.Log("Perdemos vida");
            this.ReseteamosLaPosicion();
        }
    }

    private void ReseteamosLaPosicion()
    {
        /*
         * Volvemos a poner la bola como hija de la pala, para
         * eso actuamos sobre el compoenten Transform del GameObject
         * */
        this.transform.parent = this.pala.transform;

        /*
         * Como la bola lleva una velocidad, vamos a poner la velocidad a 0
         * Para actuar sobre la velocidad o la fuerza de un objeto, tenemos
         * que hacerlo sobre su RigidBody
         * Podemos igualarla a Vector2.zero (0, 0), o multiplicar la velocidad por 0 y
         * seguro que hay mas métodos
         * */
        this.bolaRigidBody.velocity = Vector2.zero;

        /*
         * Establecemos la posición local de la bola dentro de la pala,
         * es decir establecemos su posición en X y en Y respecto del centro de la
         * pala, que es el padre
         * Como no podemos modificar directamente el transform.localPosition, definimos
         * un Vector2
         * */
        Vector2 posicionLocalRespectoDelPadre = new Vector2(0.25f, 1.25f);
        this.transform.localPosition = posicionLocalRespectoDelPadre;


        /*
         * Indicamos al script que la bola ya NO está en movimiento y 
         * así podemos volver a lanzarla
         * estaEnMovimiento = false;
         * */
        this.estaEnMovimiento = false;
    }
}
