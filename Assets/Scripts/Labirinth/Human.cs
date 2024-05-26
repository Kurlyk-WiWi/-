using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;
using static System.Math;

namespace Labirinth
{
     public enum Command
     {
        brace=0, up, down, right, left, 
        jump_1_up, jump_1_down, jump_1_right, jump_1_left,
        jump_2_up, jump_2_down, jump_2_right, jump_2_left,
     }
    public class Human : MonoBehaviour
    {
        [SerializeField] private float s;
        private float compare=20;
        //для прыжка
        private bool lift = true;
        public List<Command> commands;
        public Rigidbody2D rb;
        public  BoxCollider2D field;
        public float field_scale; //размер поля
        public int current=0;
        public Vector2 now;
        public GameObject door;
        public List<GameObject> bags;
        private bool repeat=false;
        public Human()
        {
            commands = new List<Command>();
            bags = new List<GameObject>();
            
        }
        public void Start()
        {
            field_scale = field.transform.localScale.x*1.305f;
        }
        public void SetCommands(List <Command> commands)
        {
            this.commands = commands.ToList();
            rb = GetComponent<Rigidbody2D>();
            current = 0;
            Debug.Log(this.commands.Count);
            lift = true; //jumptspeed = multipler * s;
            now = rb.transform.position;
            repeat = true;
        }
        private void FixedUpdate()
        {
            if (commands.Count == current)
            {
                Win();
                return; }
            switch (commands[current])
            {
                case 0:
                    current++;
                    break;
                case Command.up:
                    if (now.y >= field.transform.position.y + (field_scale * 3 / 4))
                        Lose();
                    if (MeetBag(now.y + (field_scale / 2), now.x)) Lose();
                    if (rb.position.y <= now.y + (field_scale / 2))
                        rb.transform.Translate(Vector2.up * s * Time.deltaTime);
                    if (rb.position.y >= now.y + (field_scale / 2))
                    { now = rb.position; current++;}
                    break;
                case Command.down:
                    if (now.y < field.transform.position.y - (field_scale*3/4))
                    { Lose(); }
                    if (MeetBag(now.y - (field_scale / 2), now.x)) Lose();
                    if (rb.position.y >= now.y - (field_scale / 2))
                        transform.Translate(Vector2.down * s * Time.deltaTime);
                    if (rb.position.y <= now.y - (field_scale / 2))
                    { now = rb.position; current++; }
                    break;
                case Command.right:
                    if (now.x > field.transform.position.x + (field_scale  / 2))
                    { Lose(); }
                    if (MeetBag(now.y , now.x+ (field_scale / 2))) Lose();
                    if (rb.position.x <= now.x + (field_scale / 2))
                        transform.Translate(Vector2.right * s * Time.deltaTime);
                    if (rb.position.x >= now.x + (field_scale / 2))
                    { now = rb.position; current++; }
                    break;
                case Command.left:
                    if (now.x < field.transform.position.x - (field_scale / 2))
                    { Lose(); }
                    if (MeetBag(now.y, now.x - (field_scale / 2))) Lose();
                    if (rb.position.x >= now.x - (field_scale / 2))
                        transform.Translate(Vector2.left * s * Time.deltaTime);
                    if (rb.position.x <= now.x - (field_scale / 2))
                    { now = rb.position; current++; }
                    break;
                case Command.jump_1_left:
                    if (now.x <= field.transform.position.x )
                        Lose();
                    if (MeetBag(now.y, now.x - field_scale)) Lose();
                    if (rb.position.x >= now.x - field_scale)
                            {
                                transform.Translate(Vector2.left * s * Time.deltaTime);
                                if (lift)
                                {
                                    transform.Translate(Vector2.up * s * Time.deltaTime);
                                    if (rb.position.y >= now.y + (field_scale / 2))
                                    { lift = false; }
                                }
                                else
                                {
                                    if (rb.position.y >= now.y)
                                    {
                                        transform.Translate(Vector2.down * s * Time.deltaTime);
                                    }
                                }
                            }
                    else
                            { now = rb.position; current++; lift = true;}
                    break;
                case Command.jump_1_right:
                    if (now.x >= field.transform.position.x)
                        Lose();
                    if (MeetBag(now.y, now.x + field_scale)) Lose();
                    if (rb.position.x <= now.x + field_scale)
                    {
                        transform.Translate(Vector2.right * s * Time.deltaTime);
                        if (lift)
                        {
                            transform.Translate(Vector2.up * s * Time.deltaTime);
                            if (rb.position.y >= now.y + (field_scale / 2))
                            { lift = false; }
                        }
                        else
                        {
                            if (rb.position.y >= now.y)
                            {
                                transform.Translate(Vector2.down * s * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true;
                        //transform.Translate(Vector2.down * 25);
                    }
                    break;
                case Command.jump_1_up:
                    if (now.y >= field.transform.position.y)
                        Lose();
                    if (MeetBag(now.y + field_scale, now.x)) Lose();
                    if (rb.position.y <= now.y + field_scale)
                    {
                        transform.Translate(Vector2.up * s * Time.deltaTime);
                        if (lift)
                        {
                            transform.Translate(Vector2.right * s * Time.deltaTime);
                            if (rb.position.x >= now.x + (field_scale / 2))
                            { lift = false; }
                        }
                        else
                        {
                            if (rb.position.x >= now.x)
                            {
                                transform.Translate(Vector2.left * s * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true;
                        //transform.Translate(Vector2.left * 25);
                    }
                    break;
                case Command.jump_1_down:
                    if (now.y <= field.transform.position.y)
                        Lose();
                    if (MeetBag(now.y - field_scale, now.x)) Lose();
                    if (rb.position.y >= now.y - field_scale)
                    {
                        transform.Translate(Vector2.down * s * Time.deltaTime);
                        if (lift)
                        {
                            transform.Translate(Vector2.left * s * Time.deltaTime);
                            if (rb.position.x <= now.x - (field_scale / 2))
                            { lift = false; }
                        }
                        else
                        {
                            if (rb.position.x <= now.x)
                            {
                                transform.Translate(Vector2.left * s * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true;
                        transform.Translate(Vector2.right * 25);
                    }
                    break;
                case Command.jump_2_left:
                    if (now.x < field.transform.position.x+field_scale/2)
                        Lose();
                    if (MeetBag(now.y, now.x - field_scale*1.5f)) Lose();
                    if (rb.position.x >= now.x - field_scale*1.5)
                    {
                        transform.Translate(Vector2.left * s * Time.deltaTime);
                        if (lift)
                        {
                            transform.Translate(Vector2.up * s * Time.deltaTime);
                            if (rb.position.y >= now.y + field_scale*0.7 )
                            { lift = false; }
                            Debug.Log("вверх");
                        }
                        else
                        {
                            if (rb.position.y >= now.y)
                            {
                                transform.Translate(Vector2.down * s * Time.deltaTime);
                                Debug.Log("вниз");

                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true;
                        //transform.Translate(Vector2.down * 49f);
                    }
                    break;
                case Command.jump_2_right:
                    if (now.x >= field.transform.position.x - field_scale / 2)
                        Lose();
                    if (MeetBag(now.y, now.x + field_scale * 1.5f)) Lose();
                    if (rb.position.x <= now.x + field_scale*1.5)
                    {
                        transform.Translate(Vector2.right * s * Time.deltaTime);
                        if (lift)
                        {
                            transform.Translate(Vector2.up * s * Time.deltaTime);
                            if (rb.position.y >= now.y + field_scale *0.7)
                            { lift = false;}
                        }
                        else
                        {
                            if (rb.position.y >= now.y)
                            {
                                transform.Translate(Vector2.down * s * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; 
                    }
                    break;
                case Command.jump_2_up:
                    if (now.y >= field.transform.position.y - field_scale / 2)
                        Lose();
                    if (MeetBag(now.y + field_scale * 1.5f, now.x)) Lose();
                    if (rb.position.y <= now.y + field_scale * 1.5)
                    {
                        transform.Translate(Vector2.up * s * Time.deltaTime);
                        if (lift)
                        {
                            transform.Translate(Vector2.right * s * Time.deltaTime);
                            if (rb.position.x >= now.x + field_scale*0.7)
                            { lift = false; }
                        }
                        else
                        {
                            if (rb.position.x >= now.x)
                            {
                                transform.Translate(Vector2.left * s * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true;
                    }
                    break;
                case Command.jump_2_down:
                    if (now.y <= field.transform.position.y + field_scale / 2)
                        Lose();
                    if (MeetBag(now.y - field_scale * 1.5f, now.x)) Lose();
                    if (rb.position.y >= now.y - field_scale * 1.5)
                    {
                        transform.Translate(Vector2.down * s * Time.deltaTime);
                        if (lift)
                        {
                            transform.Translate(Vector2.left * s * Time.deltaTime);
                            if (rb.position.x <= now.x - field_scale *0.7)
                            { lift = false; }
                        }
                        else
                        {
                            if (rb.position.x <= now.x)
                            {
                                transform.Translate(Vector2.right * s * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true;
                    }
                    break;
            }
        }
        public GameObject win;
        public void Win()
        {
            if (win.activeSelf) return;
            if (Abs(rb.transform.position.x - door.transform.position.x) < compare &&
                Abs(rb.transform.position.y - door.transform.position.y) < compare)
            {
                win.SetActive(true); repeat = false;
            }
            else if (commands.Count>0 && repeat) Lose();
        }
        public bool MeetBag(float x, float y)
        {
            for(int i=0; i<bags.Count; i++)
            {
                if (Abs(x - bags[i].transform.position.x) < compare &&
                    Abs(y - bags[i].transform.position.y) < compare)
                    return true;
            }
            return false;
        }
        public GameObject lose;
        public void Lose()
        {
            if(lose.activeSelf) return;
            if (win.activeSelf) return;
            lose.SetActive(true);
            current=commands.Count;
            repeat = false;
        }
    }
}
