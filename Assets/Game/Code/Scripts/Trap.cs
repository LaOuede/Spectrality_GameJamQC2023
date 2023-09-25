using UnityEngine;

public class Trap : A_Toggleable
{
    public GameObject DeathZone;
    [SerializeField] Animation _animation;

    public override void Activate()
    {
        //Debug.Log("Activating");
        IsActive = true;
        DeathZone.SetActive(IsActive);
        _animation.Play("Anim_Spikes_Activate");
    }
    public override void Deactivate()
    {
        //Debug.Log("Deactivating");
        IsActive = false;
        DeathZone.SetActive(IsActive);
        _animation.Play("Anim_Spikes_Deactivate");
    }

}
