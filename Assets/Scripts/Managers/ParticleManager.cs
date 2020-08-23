using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using S = UnityEngine.SerializeField;

public sealed class ParticleManager : Singleton<ParticleManager>
{
    Dictionary<ParticleSystem, ParticleSystem> particlePrefabInstanceDictionary =
        new Dictionary<ParticleSystem, ParticleSystem>();

    [S] ParticleSystem explosion;

    public ParticleSystem Explosion => explosion;


    public void SpawnParticle(ParticleSystem ps, Vector3 position, int particleCount)
    {
        ParticleSystem instance = GetParticleSystem(ps);
        var emitParams = new ParticleSystem.EmitParams();
        instance.transform.position = position;
        emitParams.position = position;
        emitParams.applyShapeToPosition = true;
        instance.Emit(emitParams, particleCount);
    }


    ParticleSystem GetParticleSystem(ParticleSystem psPrefab)
    {
        if (!particlePrefabInstanceDictionary.ContainsKey(psPrefab))
        {
            particlePrefabInstanceDictionary.Add(psPrefab, Instantiate(psPrefab));
        }

        return particlePrefabInstanceDictionary[psPrefab];
    }
}