using UnityEngine;

public class Emoujar : MonoBehaviour
{
    //Fuerza del personaje
    public float Empuje = 5.0f;
    private float obtenerMasa; //Este valor se adquiere cuando choquemos con los objetos

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody objeto = hit.collider.attachedRigidbody;

        //
        if (objeto == null || objeto.isKinematic) {
            return;
        }
        if (hit.moveDirection.y < -0.3){
            return;
        }
        obtenerMasa = objeto.mass;
        Vector3 empujeDir = new Vector3(hit.moveDirection.x,0,hit.moveDirection.z);

        objeto.linearVelocity = empujeDir * Empuje/obtenerMasa;
    }
}
