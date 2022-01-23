using Cinemachine;
using Player;
using UnityEngine;

namespace UI
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
          
        private void Start()
        {
            cinemachineVirtualCamera.Follow = FindObjectOfType<PlayerBehaviour>().gameObject.transform;
        }
    }
}
