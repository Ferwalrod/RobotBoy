using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenInteractuable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public InteractuableType Type;
    [HideInInspector]
    public bool IsActivated;

    [SerializeField]
    public DoorScript attachedDoor;

    void Start()
    {
        IsActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Type.Equals(InteractuableType.ACTIVABLE))
        {
            if (IsActivated)
            {
                attachedDoor.Unlocked = true;
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (attachedDoor != null)
            {
                Debug.LogError("There's no Attached Door");
            }
        }
    }

    public enum InteractuableType
    {
        DESTRUCTIBLE,ACTIVABLE
    }
}
