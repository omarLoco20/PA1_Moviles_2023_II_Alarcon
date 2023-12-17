using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonReturn : MonoBehaviour
{
    // Asigna tu panel y cualquier otro objeto que necesites en el Inspector
    public GameObject panel;

    private void Start()
    {
        // Obtiene la referencia al bot�n
        Button boton = GetComponent<Button>();

        // A�ade un listener al bot�n
        boton.onClick.AddListener(RestablecerEscena);
    }

    private void RestablecerEscena()
    {
        // L�gica para restablecer la escena aqu�
        // Puedes reiniciar valores, ocultar/mostrar elementos, etc.

        Debug.Log("Escena restablecida");

        // Por ejemplo, desactivar el panel
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}

