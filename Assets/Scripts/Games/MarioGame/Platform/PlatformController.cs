// using System.Collections.Generic;
// using DI.Services.Constants;
// using UnityEngine;
//
// namespace UI.Games.MarioGame.Platform
// {
//     public class PlatformController : MonoBehaviour
//     {
//         [SerializeField] private List<Transform> points;
//         [SerializeField] private float platformSpeed;
//         [SerializeField] private int target;
//   
//         private void Update()
//         {
//             transform.position = Vector3.MoveTowards(transform.position, points[target].position,
//                 platformSpeed * Time.deltaTime);
//         }
//
//         private void FixedUpdate()
//         {
//             if (transform.position != points[target].position) return;
//             if (target == points.Count - 1)
//             {
//                 target = 0;
//             }
//             else
//             {
//                 target += 1;
//             }
//         }
//
//         private void OnCollisionEnter2D(Collision2D other)
//         {
//             if (other.collider.CompareTag(Tags.PLAYER_TAG))
//             {
//                 other.gameObject.transform.SetParent(transform);
//             }
//         }
//
//         private void OnCollisionExit2D(Collision2D other)
//         {
//             if (other.collider.CompareTag(Tags.PLAYER_TAG))
//             {
//                 other.gameObject.transform.SetParent(null);
//             }
//         }
//     }
// }