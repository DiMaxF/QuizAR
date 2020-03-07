using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public enum Menu : int
{
    Game = 0,
    End = 1
}
public class IController : MonoBehaviour
{
    private static IController _instance;
    public static IController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<IController>();
            return _instance;
        }
    }

    private Dictionary<Menu, IElements[]> _elements;

    private void Start()
    {
        _elements = new Dictionary<Menu, IElements[]>();

        string[] names = Enum.GetNames(typeof(Menu));
        Menu[] values = (Menu[])Enum.GetValues(typeof(Menu));
        for (int i = 0; i < values.Length; i++)
        {
            _elements.Add(values[i], GameObject.Find(names[i]).transform.GetComponentsInChildren<ElementsMenu>());
        }
    }
    public void ShowMenu(Menu menu)
    {
        _elements.Where(m => m.Key == menu).First().Value.ToList().ForEach(m => m.Show());
        _elements.Where(m => m.Key != menu).ToList().ForEach(m => m.Value.ToList().ForEach(el => el.Hide()));
    }

    public void HideMenu(Menu menu)
    {
        _elements.Where(m => m.Key == menu).First().Value.ToList().ForEach(m => m.Hide());
        _elements.Where(m => m.Key != menu).ToList().ForEach(m => m.Value.ToList().ForEach(el => el.Show()));
    }
}