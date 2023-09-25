using UnityEngine;

public class DisplayTooltip : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.ToolTip.SetActive(false);
    }
}
