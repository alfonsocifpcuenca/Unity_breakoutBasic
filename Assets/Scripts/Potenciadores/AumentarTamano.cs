using UnityEngine;

public class AumentarTamano : Potenciador
{
    [SerializeField]
    private Vector3 escalaPala;

    private void OnDestroy()
    {
        this.transform.localScale = this.escalaPala;   
    }

    public override void Aplicar()
    {
        this.escalaPala = this.transform.localScale;

        this.transform.localScale = new Vector3(this.transform.localScale.x * 1.5f, this.transform.localScale.y, this.transform.localScale.z);
        Destroy(this, 10);
    }
}
