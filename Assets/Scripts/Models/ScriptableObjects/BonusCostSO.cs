using System.Collections.Generic;
using Models.ClassModels;
using UnityEngine;

namespace Models.ScriptableObjects
{[CreateAssetMenu(fileName = "BonusCost", menuName = "ScriptableObjects/BonusCost", order = 1)]
    public class BonusCostSO : ScriptableObject
    {
        [SerializeField] private List <BonusCost> bonusCosts = new List <BonusCost> ();
        public List <BonusCost>  BonusCosts => bonusCosts; 
    }
}