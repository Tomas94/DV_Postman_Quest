using UnityEngine;

public class PushBlocks : MonoBehaviour
{
    public float pushForce = 10f;
    public float pullForce = 5f;
    public float maxDistance = 10f;
    public LayerMask boxLayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithBox();
        }
    }

    private void InteractWithBox()
    {
        RaycastHit hit;

        // Lanzar un rayo hacia adelante desde la posici�n del jugador
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, boxLayer))
        {
            // Obtener el objeto golpeado
            GameObject hitObject = hit.collider.gameObject;

            // Verificar si el objeto golpeado tiene un Rigidbody (es una caja)
            Rigidbody boxRigidbody = hitObject.GetComponent<Rigidbody>();

            if (boxRigidbody != null)
            {
                boxRigidbody.isKinematic = false;

                // Calcular la direcci�n relativa entre el jugador y la caja
                Vector3 directionToBox = hitObject.transform.position - transform.position;
                directionToBox.y = 0; // Ignorar la componente y

                // Normalizar la direcci�n
                directionToBox.Normalize();

                // Aplicar fuerza al Rigidbody de la caja para empujarla o tirar de ella
                if (Vector3.Dot(directionToBox, transform.forward) > 0)
                {
                    // Empujar hacia adelante
                    boxRigidbody.AddForce(transform.forward * pushForce, ForceMode.Impulse);
                }
                else
                {
                    // Tirar hacia atr�s
                    boxRigidbody.AddForce(-transform.forward * pullForce, ForceMode.Impulse);
                }
            }
        }
    }
}
