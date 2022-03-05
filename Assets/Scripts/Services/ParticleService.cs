using System.Collections.Generic;
using System.Linq;
using Models.Enum;
using Models.ScriptableObjects;
using Services.Interfaces;
using UnityEngine;
using Utility;

namespace Services
{
    public class ParticleService : MonoBehaviour, IParticleService
    {
        [SerializeField] private List<ParticleComponentSO> particleComponents;

        public void InitializeParticle(RewardType rewardType, Vector3 position)
        {
            var particleSystem = particleComponents.First(x => x.ParticleType == rewardType).ParticleSystem;
            var instantiatedParticle =
                Instantiate(particleSystem, position, Quaternion.identity, transform);
            StartCoroutine(ExtensionUtility.StartWithDelay(instantiatedParticle.main.duration,
                () => Destroy(instantiatedParticle)));
        }
    }
}