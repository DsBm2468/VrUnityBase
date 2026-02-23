using UnityEngine;

public class AgarrarObjeto : MonoBehaviour
{
    public bool esAgarrable = true; //bool es booleano, sirve igual asi

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZonadeInteraccion")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject;
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
