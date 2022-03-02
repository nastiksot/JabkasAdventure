using UI.Levels;
using UnityEngine;

namespace Zenject
{
    public class EnemyMarker : MonoBehaviour
    {
        [SerializeField] private Transform enemyTransformPoint;
        [SerializeField] private EnemyType enemyType;
        public Transform EnemyTransformPoint => enemyTransformPoint;
        public EnemyType EnemyType => enemyType;

    }
}