using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [field: SerializeField] public Item ItemRef { get; private set; }
}
