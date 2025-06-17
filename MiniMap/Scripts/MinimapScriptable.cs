using UnityEngine;

[CreateAssetMenu(fileName = "MinimapScriptable", menuName = "Scriptable Objects/MinimapScriptable")]
public class MinimapScriptable : ScriptableObject
{
    public float CameraHeight = 16.0f;
    public Vector3 CameraPosition;
    public float CameraProjectionSize;

}
