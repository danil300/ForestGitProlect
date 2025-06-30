using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "MyGame/ScriptableObject")]
public class Items : ScriptableObject
{
    public string NameItem;
    public GameObject itemOnScene;
    public GameObject itemIcon;
}
