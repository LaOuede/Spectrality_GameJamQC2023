using UnityEngine;

public abstract class A_Interactible : MonoBehaviour
{
    public bool isUsable;
    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void OnTriggerExit(Collider other);
    public abstract bool Interact();
}
