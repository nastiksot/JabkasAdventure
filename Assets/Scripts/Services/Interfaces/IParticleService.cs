using Models.Enum;
using UnityEngine;

namespace Services.Interfaces
{
    public interface IParticleService
    {
        public void InitializeParticle(ParticleType particleType, Vector3 position);
    }
}