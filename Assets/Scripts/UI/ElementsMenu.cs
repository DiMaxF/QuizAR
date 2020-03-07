using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsMenu : MonoBehaviour, IElements
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void InstantHide()
    {
        gameObject.SetActive(false);
    }
}

