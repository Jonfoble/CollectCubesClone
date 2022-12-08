using UnityEngine;

namespace Jonfoble.ScriptableSystem 
{
    [CreateAssetMenu(menuName = "Jonfoble/ScriptableObjects/ScriptableLevelWithTimer")]
    public class ScriptableLevelWithTimer : ScriptableObject
    {
        [Range(0f, 60f)][SerializeField] internal float desiredTime = 60f;
        [SerializeField] internal int desiredPrefabAmount;
		[SerializeField] internal GameObject cube;
    }
}