using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty", menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    public MoveSettings MoveSettings;
    public SpawnSettings SpawnSettings;
}
