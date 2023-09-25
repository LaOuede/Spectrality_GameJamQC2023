using UnityEngine;

public class Interacter : MonoBehaviour
{
    public string TagMask;

    private bool _isInteracting = false;
    public A_Interactible Interactable;

    public bool Interact()
    {
        if (!_isInteracting)
            return false;

        if (Interactable.Interact())
        {
            //Debug.Log("Interaction successful");
            _isInteracting = false;
            Interactable = null;

            return true;
        }

        // Debug.Log("Interaction failed");
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        A_Interactible A_Interactible = other.GetComponent<A_Interactible>();

        if (A_Interactible != null)
        {
            if (other.CompareTag(TagMask))
            {
                _isInteracting = true;
                Interactable = A_Interactible;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject == _interactable) // Absence of checks might cause issue with overlapping interactibles !!! WARNING
        {
            //Debug.Log("A_Interactible lost");
            _isInteracting = false;
            Interactable = null;
        }
    }


}
