using System;
using UnityEngine;

[CreateAssetMenu(fileName = "News", menuName = "Scriptable Objects/News")]
public class News : ScriptableObject
{
    public Sprite Sprite;
    [TextArea] public string Text;
    public float TimeToStart;
}
