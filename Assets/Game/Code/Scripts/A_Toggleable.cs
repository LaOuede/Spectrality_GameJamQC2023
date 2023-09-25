using UnityEngine;

public abstract class A_Toggleable : MonoBehaviour
{
    public bool IsActive;
    public bool IsHeld;
    public bool HoldActive;

    public abstract void Activate();
	public abstract void Deactivate();

    void Start()
    {
        InitState();
    }

    public void Toggle()
    {

        if (IsActive)
            Deactivate();
        else
            Activate();
    }

    public void InitState()
    {
        if (IsActive)
            Activate();
        else
            Deactivate();
    }
}
