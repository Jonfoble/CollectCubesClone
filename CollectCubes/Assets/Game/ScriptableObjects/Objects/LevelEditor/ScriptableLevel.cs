using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jonfoble.ScriptableSystem
{
    [CreateAssetMenu(menuName = "Jonfoble/ScriptableObjects/ScriptableLevel")]
    public class ScriptableLevel : ScriptableObject
    {
        [SerializeField] internal Sprite sprite;
        [SerializeField] internal Vector2 spacing;
        [SerializeField] internal GameObject cubePrefab;
    }
}