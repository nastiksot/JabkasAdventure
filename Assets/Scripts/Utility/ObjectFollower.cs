using UnityEngine;

namespace Utility
{
    public class ObjectFollower : MonoBehaviour
    { 
        [SerializeField] protected Transform objToFollow;
        [SerializeField] protected bool setRotation;

        private void Update()
        {
            if(objToFollow == null) return;
            if (!objToFollow.gameObject.activeInHierarchy) return;
            transform.position = objToFollow.position;
            if(!setRotation) return;
            transform.rotation = objToFollow.rotation;
        }
    }
}