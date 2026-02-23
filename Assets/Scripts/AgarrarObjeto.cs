using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public bool esAgarrable = true; //bool es booleano, sirve igual asi

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
            AudioManager.Instance.Play2D("Detectar"); //va el nombre del id que pusimos en unity
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
        }
    }
}
