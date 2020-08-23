using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;

public class Explosion : AttachableModule
{
    readonly int particleCount = 42;
    public override void InvokeAction()
    {
        ParticleManager.Instance.SpawnParticle(ParticleManager.Instance.Explosion, transform.position, particleCount);
    }
}