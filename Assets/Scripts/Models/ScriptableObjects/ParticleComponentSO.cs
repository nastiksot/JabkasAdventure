using Models.Enum;
using UnityEngine;

namespace Models.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ParticleType", menuName = "ScriptableObjects/ParticleType", order = 2)]
    public class ParticleComponentSO : ScriptableObject
    {
        [SerializeField] private ParticleType particleType;
        [SerializeField] private ParticleSystem particleSystem;

        public ParticleType ParticleType => particleType;
        public ParticleSystem ParticleSystem => particleSystem;

    }
}