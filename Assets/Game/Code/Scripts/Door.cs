using UnityEngine;

public class Door : A_Toggleable
{
    [SerializeField] Animation _animation;

    public override void Activate()
    {
        // Debug.Log("Door opened");
        IsActive = true;
        _animation.Play("Anim_Door_Open");
    }
    public override void Deactivate()
    {
        // Debug.Log("Door closed");
        IsActive = false;
        _animation.Play("Anim_Door_Close");
    }
}
