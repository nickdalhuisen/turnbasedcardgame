using UnityEngine;

[CreateAssetMenu(fileName = "soundeffects", menuName = "Audio Manager/sound.effects")]
public class SoundEffects : ScriptableObject
{
    public string label;
    public AudioClip effect;
}
