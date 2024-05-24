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
            { 1, 1, 0, 0,
              0, 0, 0, 0,
              1, 0, 1, 1,
              1, 2, 1, 3 },
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
        public int human_number = door_number + 1;
        public float field_scale;
        public BoxCollider2D field;
        public float field_place_x, field_place_y;
        public Vector3[] place = new Vector3[16];
        private float const_z = 3.7f;
        public Rigidbody2D human;
        public int level_numder = 0;
        public void Start()
        {
            field_place_x = field.transform.position.x;
            field_place_y = field.transform.position.y;
            field_scale = field.transform.localScale.x;
            float x, y;
            for(int i = 0; i < place.Length; i++)
            {
                x = field_place_x - field_scale + (i % 4) * (field_scale/2*1.3f) ;
                y = field_place_y + field_scale - (i / 4) * (field_scale/2*1.3f);
                place[i]= new Vector3(x,y,const_z);
            }
            Arrangement(human, level_numder);
        }
        public void Arrangement(Rigidbody2D human,int number)
        {
            int a = 0;
            for(int i=0; i<16; i++)
            {
                switch (levels[number, i])
                {
                    case 1:
                        sprites[a].SetActive(true);
                        sprites[a].transform.position = place[i];
                        a++;
                        break;
                    case 2:
                        sprites[door_number].SetActive(true);
                        sprites[door_number].transform.position = place[i];
                        break;
                    case 3:
                        sprites[human_number].SetActive(true);
                        sprites[human_number].transform.position = place[i];
                        break;
                }
            }
        }
        public GameObject win;
        /*public void Win()
        {
            if (human.transform.position != sprites[door_number].transform.position)
            {
                win.SetActive(true);
            }
        }*/
        public void NextLevel(GameObject x)
        {
            x.SetActive(false);
            Arrangement(human, ++level_numder);
        }
    }
}