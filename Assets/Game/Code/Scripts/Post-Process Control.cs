using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessControl : MonoBehaviour
{
    [SerializeField] private bool disable;
    [SerializeField] private Volume postProcessVolume;
    [SerializeField] private VolumeProfile postProcessNormal;
    [SerializeField] private VolumeProfile postProcessSpectre;

    public void SetSpectreProcess()
    {
        postProcessVolume.profile = postProcessSpectre;
    }

    public void SetNormalProcess()
    {
        postProcessVolume.profile = postProcessNormal;
    }
}
