using UnityEngine;

public class AumentarTamano : Potenciador
{

    public override void Aplicar()
    {
        GameObject pala = GameObject.FindGameObjectWithTag("Pala");

        pala.transform.localScale = new Vector3(pala.transform.localScale.x * 2, pala.transform.localScale.y, pala.transform.localScale.z);
        Destroy(this, 5f);
    }

    onde
}
