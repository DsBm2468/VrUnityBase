using UnityEngine;

public class ActivarSonido : MonoBehaviour
{
    public GameObject post;
    public GameObject post1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //AudioManager.Instance.Play3D("Encontrar",post.transform.position); //va el nombre del id que pusimos en unity
            AudioManager.Instance.Play2D("Encontrar");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //AudioManager.Instance.Play3D("Perder",post1.transform.position);
            AudioManager.Instance.Play2D("Perder");
        }
    }
}
