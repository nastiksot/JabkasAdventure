using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UI.Base;
using UnityEngine;

namespace UI.Games.Menus
{
    public class MainMenuAnimation : MonoBehaviour
    {
        [SerializeField] private List<DictionarySerialize<RectTransform, List<int>>> transformList;
        [SerializeField] private float delay = 15f;

        private void Start()
        {
            ResetToDefaultPosition();
            StartCoroutine(StartAnimation());
        }

        private void ResetToDefaultPosition()
        {
            foreach (var imageTransform in transformList)
            {
                imageTransform.Key.localPosition =
                    new Vector2(imageTransform.Key.localPosition.x, imageTransform.Value[0]);
            }
        }

        private IEnumerator StartAnimation()
        {
            while (true)
            {
                foreach (var imageTransform in transformList)
                {
                    for (var i = 0; i < imageTransform.Value.Count; i++)
                    {
                        imageTransform.Key.DOLocalMoveY(imageTransform.Value[i], delay);
                        if (i != 1) continue;
                        yield return new WaitForSeconds(delay + 1);
                    }

                    for (var i = imageTransform.Value.Count - 1; i >= 0; i--)
                    {
                        imageTransform.Key.DOLocalMoveY(imageTransform.Value[i], delay);
                        if (i == 2)
                        {
                            yield return new WaitForSeconds(delay - 1);
                        }
                    } 
                    yield return new WaitForSeconds(delay);
                }
                
            }
        }
    }
}