using UnityEngine;


[CreateAssetMenu(fileName = "New Effect", menuName = "CardData/EffectCard")]
public class EffectCard : BaseCard
{
    public enum EffectType
    {
        Regenerate, Taunt, Spread, Spawn, Buff
    }
    public int lifeTime;
    [SerializeField]
    private EffectType thisEffect;
    public override void Play()
    {

    }
}
