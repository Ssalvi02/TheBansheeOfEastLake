using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;

public class InteractableCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}
