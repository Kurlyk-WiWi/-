using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Labirinth
{
    public class Level : MonoBehaviour
    {
        public List<GameObject> sprites = new List<GameObject>();
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
        public int number = 0, current = 0;
        public const int door_number = 7;
        public float field_scale;
        public GameObject field;
        public float field_place_x, field_place_y;
        public Vector3[] place = new Vector3[16];
        private float const_z = 3.7f;
        public Rigidbody2D human;
        public void Start()
        {
            field_place_x = field.transform.position.x;
            field_place_y = field.transform.position.y;
            float x, y;
            for(int i = 0; i < place.Length; i++)
            {
                x = field_place_x - field_scale + field_scale / 4 + (i % 4) * field_scale/2 ;
                y = field_place_y + field_scale - field_scale / 4 - (i / 4) * field_scale/2;
                place[i]= new Vector3(x,y,const_z);
            }
            Arrangement(human, 0);
        }
        public void Arrangement(Rigidbody2D human,int number)
        {
            int a = 0;
            for(int i=0; i<16; i++)
            {
                switch (levels[number,i])
                {
                    case 1:
                        sprites[a].SetActive(true);
                        sprites[a].transform.position = place[i];
                        Debug.Log("Баг поставлен по координатам: " + place[i].x + " , " + place[i].y);
                        a++;
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }
            }
        }
    }
}