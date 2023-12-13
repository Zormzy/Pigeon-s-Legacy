using UnityEngine;

[CreateAssetMenu(menuName = "Trap Data")]
public class PL_Trap_Scriptable : ScriptableObject
{
    public string name;
    public int damage;
    public float cooldown;
    public bool difused;
}
