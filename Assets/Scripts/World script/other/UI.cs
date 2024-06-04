using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [Header("_____ Visible For Debugging _____")]
    public EventSystem EventSystem;
    public List<Selectable> Selectables = new List<Selectable>();

    private void Start()
    {
        EventSystem = FindObjectOfType<EventSystem>(true);
        GetChildSelectables();
    }
    private void Update()
    {
        if (EventSystem.currentSelectedGameObject != null && EventSystem.currentSelectedGameObject.activeInHierarchy)
        {
            return;
        }
        else
        {
            foreach (var item in Selectables)
            {
                if (item.isActiveAndEnabled)
                {
                    EventSystem.SetSelectedGameObject(item.gameObject);
                    Debug.Log("Selected: " + item.name);
                    return;
                }
            }
        }
    }
    [ContextMenu("GetChildSelectables")]
    public void GetChildSelectables()
    {
        Selectables.Clear();
        Selectables.AddRange(gameObject.GetComponentsInChildren<Selectable>(true));
    }
}
