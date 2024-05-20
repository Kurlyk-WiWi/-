using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Labirinth
{
    public class Level : MonoBehaviour
    {
        public int[,] levels = new int[5, 16]
        {
            { 0, 0, 1, 0,
              1, 0, 0, 2,
              1, 0, 1, 1,
              1, 3, 1, 0 },
            { 2, 0, 1, 0,
              1, 0, 0, 1,
              1, 1, 0, 0,
              1, 0, 1, 3 },
            { 0, 1, 0, 0,
              0, 1, 1, 1,
              2, 1, 0, 3,
              0, 0, 1, 0 },
            { 2, 0, 1, 0,
              0, 1, 0, 0,
              0, 1, 1, 0,
              0, 0, 1, 3 },
            { 0, 0, 1, 0,
              1, 0, 0, 2,
              1, 0, 1, 1,
              1, 0, 1, 0 }
        };

        public void Arrangement(int[] level)
        {

        }
    }
}