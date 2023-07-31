using UnityEngine;

[CreateAssetMenu]
public class SettingsLoadData : ScriptableObject
{
    public bool isFireBase = true;
    public bool isLocalBase = false;
    public bool isDefault = false;
    //для передачик команд
    public bool isStartUpload = false;
    public bool isSave = true;
}
