using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        // Cargar la escena principal del juego
        SceneManager.LoadScene("SampleScene");
    }
}
