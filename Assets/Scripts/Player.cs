using System;
using UnityEngine;

public class JUGADOR : MonoBehaviour
{
    // Movimiento Basico
    public CharacterController Controlador; // Referencia al componente CharacterController del jugador
    public float Velocidad = 15f;
    public float Gravedad = -9.81f;
    public float FuerzaSalto = 3f;

    // Manejo de la gravedad y el salto
    public Transform EnelPiso; // Transform que representa el punto desde donde se verifica si el jugador está en el suelo
    public float DistanciaPiso; // Distancia para verificar si el jugador está en el suelo
    public LayerMask Piso; // Capa que representa el suelo

    // Variables para el manejo de la caída y el salto
    Vector3 VelocidadCaida;
    bool EnSuelo; //Esta en el piso

    //Camara
    public Camera mainCamera; // Referencia a la cámara principal del juego
    private Vector3 camForward; // Vector que representa la dirección hacia adelante de la cámara
    private Vector3 camRight; // Vector que representa la dirección hacia la derecha de la cámara
    private Vector3 moverJugador;
    private Vector3 mover;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnSuelo = Physics.CheckSphere(EnelPiso.position, DistanciaPiso, Piso); // Verifica si el jugador está en el suelo utilizando una esfera de colisión
        if (EnSuelo && VelocidadCaida.y < 0)
        {
            VelocidadCaida.y = -2f; // Si el jugador está en el suelo y tiene una velocidad de caída negativa, se establece una pequeña velocidad hacia abajo para mantenerlo pegado al suelo
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        mover = new Vector3(x, 0, z); // Crea un vector de movimiento basado en la entrada del jugador para los ejes horizontal y vertical
        moverJugador = Vector3.ClampMagnitude(moverJugador, 1); // Limita la magnitud del vector de movimiento del jugador a 1 para evitar que se mueva más rápido en diagonal
        moverJugador = mover.x * camRight + mover.z * camForward; // Convierte el vector de movimiento del jugador a un movimiento relativo a la cámara utilizando las direcciones hacia adelante y hacia la derecha de la cámara
        Controlador.Move(moverJugador * Velocidad * Time.deltaTime); // Mueve al jugador utilizando el CharacterController, multiplicando por la velocidad y el tiempo entre frames para un movimiento suave
        Controlador.transform.LookAt(Controlador.transform.position + moverJugador); // Hace que el jugador mire en la dirección del movimiento

        if (Input.GetButtonDown("Jump") && EnSuelo)
        {
            VelocidadCaida.y = Mathf.Sqrt(FuerzaSalto * -2f * Gravedad); // Si el jugador presiona el botón de salto y está en el suelo, se calcula la velocidad de salto utilizando la fórmula de la física para un salto
        }
        VelocidadCaida.y += Gravedad * Time.deltaTime; // Aplica la gravedad a la velocidad de caída del jugador

        Controlador.Move(VelocidadCaida * Time.deltaTime); // Mueve al jugador utilizando el CharacterController, aplicando la velocidad de caída para simular la gravedad

        DireccionCamera(); // Llama al método para actualizar las direcciones de la cámara en cada frame
    }

    void DireccionCamera()
    {
        camForward = mainCamera.transform.forward; // Obtiene la dirección hacia adelante de la cámara
        camRight = mainCamera.transform.right; // Obtiene la dirección hacia la derecha de la cámara

        camForward.y = 0; // Elimina la componente vertical de la dirección hacia adelante para mantener el movimiento en el plano horizontal
        camRight.y = 0; // Elimina la componente vertical de la dirección hacia la derecha para mantener el movimiento en el plano horizontal

        camForward = camForward.normalized; // Normaliza el vector de dirección hacia adelante para obtener una magnitud de 1
    }
}