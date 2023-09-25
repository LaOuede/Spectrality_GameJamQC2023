using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("ScnStart");
    }
}