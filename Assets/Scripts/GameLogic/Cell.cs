using System;
using UnityEngine;

namespace GameLogic
{
    [Serializable]
    public class Cell
    {
        [field: SerializeField] public Sign Sign { get; set; } = Sign.None;
        public bool IsEmpty() => Sign == Sign.None;

        public void PutSign(Sign playerSign) =>
            Sign = playerSign;
    }
}