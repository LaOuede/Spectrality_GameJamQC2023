using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Text_display : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    void Start()
    {
        levelText.SetText("Floor " + SceneManager.GetActiveScene().buildIndex);
    }
}
