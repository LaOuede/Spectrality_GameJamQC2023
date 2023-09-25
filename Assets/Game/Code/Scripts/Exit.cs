using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : A_Interactible
{
    public int _level;
    public static Action OnExit;

    protected override void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name + " touched an exit");
        A_Player player = other.GetComponentInParent<A_Player>();

        if (player && player.type.Equals("Human"))
        {
            //Debug.Log($"You completed Floor #{_level}!"); // DEBUG

            OnExit?.Invoke();
            StartCoroutine(StartExit());
        }
    }

    IEnumerator StartExit()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(_level);
    }

    protected override void OnTriggerExit(Collider other)
    {
        return;
    }

    public override bool Interact()
    {
        return true;
    }

}
