using UnityEngine;

namespace Utility
{
    public class ObjectFollower : MonoBehaviour
    {
        [SerializeField] protected Transform objToFollow;
        [SerializeField] protected bool setRotation;

        protected Vector3 offsetPosition;

        protected void Update()
        {
            if (objToFollow == null) return;
            if (!objToFollow.gameObject.activeInHierarchy) return;
            SetPosition();
            SetRotation();
        }

        public virtual void SetPosition()
        {
            var followedPosition = objToFollow.position;
            transform.position = followedPosition + offsetPosition;
        }

        public virtual void SetRotation()
        {
            if (!setRotation) return;
            transform.rotation = objToFollow.rotation;
        }

        public void SetOffsetPosition(Vector3 offsetData)
        {
            offsetPosition = offsetData;
        }
    }
}