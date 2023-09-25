using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGM;

    public void ChangeBGM(AudioClip clip)
    {
        BGM.Stop();
        BGM.clip = clip;
        BGM.Play();
        BGM.loop = true;
    }

    public void PlaySFX(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, GameManager.Instance.MainCamera.transform.position, 1f);
    }


}
