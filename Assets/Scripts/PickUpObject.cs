using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //Creacion de variables

    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform ZonadeInteraccion;
    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<AgarrarObjeto>().esAgarrable == true && PickedObject == null)
        {
            if (Input.GetButtonDown("Firel"))
            {
                //agarar objeto
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<AgarrarObjeto>().esAgarrable = false;//cuando no es agarragle,
                PickedObject.transform.SetParent(ZonadeInteraccion);// se convierte en hijo de la zonadeinteracion
                PickedObject.transform.position = ZonadeInteraccion.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        } else if (PickedObject != null)
        {
            if (Input.GetButtonDown("Firel"))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<AgarrarObjeto>().esAgarrable = true;//cuando no es agarragle,
                PickedObject.transform.SetParent(null);// se covierte en hijo de la zonadeinteracion
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }
    }
}