using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

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
        //для прыжка
        public float acceleration = 8f;
        public float jumptspeed = 0;
        private bool lift = true;
        public List<Command> commands;
        public List<Command> code;
        public Rigidbody2D rb;
        public  Rigidbody2D field;
        public int door, massiv; // клеточка двери и двоичное кодировка наличия багов на поле
        public float field_scale; //размер поля
        public int current=0;
        public Vector2 now;
        public Human()
        {
            commands = new List<Command>();
            code = new List<Command>();
        }
        public void SetCommands(List <Command> commands)
        {
            this.commands = commands.ToList();
            Debug.Log(this.code.Count);
        }
        // Start is called before the first frame update
        void Start()
        {
            rb=GetComponent<Rigidbody2D>();
            now = rb.position;
            jumptspeed = 2 * s;
        }

        // Update is called once per frame
        void Update()
        {}
        private void FixedUpdate()
        {
            //if (commands.Count == 0) return;
            if (commands.Count == current) return;
            switch (commands[current])
            {
                case 0:
                    current++;
                    break;
                case Command.up:
                    if (rb.position.y <= now.y + (field_scale / 2))
                        rb.transform.Translate(Vector2.up * s * Time.deltaTime);
                    if (rb.position.y >= now.y + (field_scale / 2))
                    { now = rb.position; current++;}
                    break;
                case Command.down:
                    if (rb.position.y >= now.y - (field_scale / 2))
                        transform.Translate(Vector2.down * s * Time.deltaTime);
                    if (rb.position.y <= now.y - (field_scale / 2))
                    { now = rb.position; current++; }
                    break;
                case Command.right:
                    if (rb.position.x <= now.x + (field_scale / 2))
                        transform.Translate(Vector2.right * s * Time.deltaTime);
                    if (rb.position.x >= now.x + (field_scale / 2))
                    { now = rb.position; current++; }
                    break;
                case Command.left:
                    if (rb.position.x >= now.x - (field_scale / 2))
                        transform.Translate(Vector2.left * s * Time.deltaTime);
                    if (rb.position.x <= now.x - (field_scale / 2))
                    { now = rb.position; current++; }
                    break;
                case Command.jump_1_left:
                    if (rb.position.x >= now.x - field_scale)
                            {
                                transform.Translate(Vector2.left * s * Time.deltaTime);
                                if (lift)
                                {
                                    jumptspeed -= acceleration;
                                    transform.Translate(Vector2.up * jumptspeed * Time.deltaTime);
                                    if (rb.position.y >= now.y + (field_scale / 2))
                                    { lift = false; jumptspeed = 0; }
                                }
                                else
                                {
                                    if (rb.position.y >= now.y)
                                    {
                                        jumptspeed += acceleration;
                                        transform.Translate(Vector2.down * jumptspeed * Time.deltaTime);
                                    }
                                }
                            }
                    else
                            { now = rb.position; current++; lift = true; jumptspeed = 2*s;
                            //transform.Translate(Vector2.down * 25);
                            }
                    break;
                case Command.jump_1_right:
                    if (rb.position.x <= now.x + field_scale)
                    {
                        transform.Translate(Vector2.right * s * Time.deltaTime);
                        if (lift)
                        {
                            jumptspeed -= acceleration;
                            transform.Translate(Vector2.up * jumptspeed * Time.deltaTime);
                            if (rb.position.y >= now.y + (field_scale / 2))
                            { lift = false; jumptspeed = 0; }
                        }
                        else
                        {
                            if (rb.position.y >= now.y)
                            {
                                jumptspeed += acceleration;
                                transform.Translate(Vector2.down * jumptspeed * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; jumptspeed = 2*s;
                        //transform.Translate(Vector2.down * 25);
                    }
                    break;
                case Command.jump_1_up:
                    if (rb.position.y <= now.y + field_scale)
                    {
                        transform.Translate(Vector2.up * s * Time.deltaTime);
                        if (lift)
                        {
                            jumptspeed -= acceleration;
                            transform.Translate(Vector2.right * jumptspeed * Time.deltaTime);
                            if (rb.position.x >= now.x + (field_scale / 2))
                            { lift = false; jumptspeed = 0; }
                        }
                        else
                        {
                            if (rb.position.x >= now.x)
                            {
                                jumptspeed += acceleration;
                                transform.Translate(Vector2.left * jumptspeed * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; jumptspeed = 2*s;
                        //transform.Translate(Vector2.left * 25);
                    }
                    break;
                case Command.jump_1_down:
                    if (rb.position.y >= now.y - field_scale)
                    {
                        transform.Translate(Vector2.down * s * Time.deltaTime);
                        if (lift)
                        {
                            jumptspeed -= acceleration;
                            transform.Translate(Vector2.left * jumptspeed * Time.deltaTime);
                            if (rb.position.x <= now.x - (field_scale / 2))
                            { lift = false; jumptspeed = 0; }
                        }
                        else
                        {
                            if (rb.position.x <= now.x)
                            {
                                jumptspeed += acceleration;
                                transform.Translate(Vector2.left * jumptspeed * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; jumptspeed = 2*s;
                        transform.Translate(Vector2.right * 25);
                    }
                    break;
                case Command.jump_2_left: // хуита
                    if (rb.position.x >= now.x - field_scale*1.5)
                    {
                        transform.Translate(Vector2.left * s * Time.deltaTime);
                        if (lift)
                        {
                            jumptspeed -= acceleration;
                            transform.Translate(Vector2.up * jumptspeed * Time.deltaTime);
                            if (rb.position.y >= now.y + field_scale*0.7 )
                            { lift = false; jumptspeed = 0; }
                        }
                        else
                        {
                            if (rb.position.y >= now.y)
                            {
                                jumptspeed += acceleration;
                                transform.Translate(Vector2.down * jumptspeed * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; jumptspeed = 2*s;
                        transform.Translate(Vector2.down * 49f);
                    }
                    break;
                case Command.jump_2_right:
                    if (rb.position.x <= now.x + field_scale*1.5)
                    {
                        transform.Translate(Vector2.right * s * Time.deltaTime);
                        if (lift)
                        {
                            jumptspeed -= acceleration;
                            transform.Translate(Vector2.up * jumptspeed * Time.deltaTime);
                            if (rb.position.y >= now.y + (field_scale / 2)*0.7)
                            { lift = false; jumptspeed = 0; }
                        }
                        else
                        {
                            if (rb.position.y >= now.y)
                            {
                                jumptspeed += acceleration;
                                transform.Translate(Vector2.down * jumptspeed * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; jumptspeed = 2*s;
                        transform.Translate(Vector2.down * 49f);
                    }
                    break;
                case Command.jump_2_up:
                    if (rb.position.y <= now.y + field_scale * 1.5)
                    {
                        transform.Translate(Vector2.up * s * Time.deltaTime);
                        if (lift)
                        {
                            jumptspeed -= acceleration;
                            transform.Translate(Vector2.right * jumptspeed * Time.deltaTime);
                            if (rb.position.x >= now.x + (field_scale / 2)*0.7)
                            { lift = false; jumptspeed = 0; }
                        }
                        else
                        {
                            if (rb.position.x >= now.x)
                            {
                                jumptspeed += acceleration;
                                transform.Translate(Vector2.left * jumptspeed * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; jumptspeed = 2*s;
                        transform.Translate(Vector2.left * 49f);
                    }
                    break;
                case Command.jump_2_down:
                    if (rb.position.y >= now.y - field_scale * 1.5)
                    {
                        transform.Translate(Vector2.down * s * Time.deltaTime);
                        if (lift)
                        {
                            jumptspeed -= acceleration;
                            transform.Translate(Vector2.left * jumptspeed * Time.deltaTime);
                            if (rb.position.x <= now.x - (field_scale / 2)*0.7)
                            { lift = false; jumptspeed = 0; }
                        }
                        else
                        {
                            if (rb.position.x <= now.x)
                            {
                                jumptspeed += acceleration;
                                transform.Translate(Vector2.left * jumptspeed * Time.deltaTime);
                            }
                        }
                    }
                    else
                    {
                        now = rb.position; current++; lift = true; jumptspeed = 2 * s;
                        transform.Translate(Vector2.right * 49f);
                    }
                    break;
            }
            Debug.Log(rb.position.y.ToString()+"  " +rb.position.x.ToString());
        }
    }
}
