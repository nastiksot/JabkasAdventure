using System.Collections.Generic;
using UnityEngine;

namespace UI.Games.MarioGame.Platform
{
    public class PlatformManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> points;
        [SerializeField] private float platformSpeed;
        [SerializeField] private int target;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, points[target].position, platformSpeed*Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (transform.position != points[target].position) return;
            if (target==points.Count-1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
    }
}