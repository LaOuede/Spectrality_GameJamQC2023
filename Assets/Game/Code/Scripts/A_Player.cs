using UnityEngine;
using UnityEngine.InputSystem;
using System;

public abstract class A_Player : MonoBehaviour
{
    public Action OnDeath;
    public Action OnPossess;

    public bool IsAlive;
    public bool CanBePossessed;
    public bool HasPoison = false;
    public string type = "UNINITIALIZED";

    protected MyInputs _myInputs;

    public abstract void Unalive(bool isPermanentDead);
    public abstract void GetPossessed();
    protected abstract void UpdateInputs();

    protected void ConsumePoison(InputAction.CallbackContext ctx)
    {
        if (HasPoison)
        {
            Debug.Log(name + " drank the poison");

            GameManager.Instance.PotionIcon.SetActive(false);

            HasPoison = false;
            Unalive(false);
        }
    }
    protected void DoDeath()
    {
        if (HasPoison)
            Instantiate(GameManager.Instance.PoisonObject, transform.position, Quaternion.identity);

        HasPoison = false;
        GameManager.Instance.PotionIcon.SetActive(false);

        Instantiate(GameManager.Instance.SpectreObject, transform.position, Quaternion.identity);
    }
}
