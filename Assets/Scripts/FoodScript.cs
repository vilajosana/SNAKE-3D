using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {
    // Puedes agregar más lógica aquí, por ejemplo, cuando la serpiente come la comida.
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Snake")) {
            // Lógica cuando la serpiente come la comida
            Destroy(gameObject); // O desactivar el objeto si prefieres reutilizarlo
        }
    }
}
