using UnityEngine;

namespace Utility
{
    public class ObjectFollower : MonoBehaviour
    {
        [SerializeField] protected Transform objToFollow;
        [SerializeField] protected bool setRotation;

        protected Vector3 offsetPosition;

        private void Update()
        {
            if (objToFollow == null) return;
            if (!objToFollow.gameObject.activeInHierarchy) return;
            var followedPosition = objToFollow.position;
            transform.position = followedPosition + offsetPosition;
            if (!setRotation) return;
            transform.rotation = objToFollow.rotation;
        }

        public void SetOffsetPosition(Vector3 offsetData)
        {
            offsetPosition = offsetData;
        }
    }
}