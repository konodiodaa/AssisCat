using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{

    public ElementObject eo;
    public ElementBehavior eb;

    void Awake()
    {

      //  EventCenter.AddListener()

        if (eo != ElementObject.Null  && eb != ElementBehavior.Null)
        {
            EventCenter.Broadcast(EventType.ChangeElementCombination, eo, eb);
        }
    }

    private void 
}
