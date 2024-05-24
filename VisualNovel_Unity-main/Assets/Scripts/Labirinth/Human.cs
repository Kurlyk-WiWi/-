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
        public Human()
        {
            commands = new List<Command>();
            
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
            now = rb.position;
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
                case Command.jump_2_left: // хуита
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
            if (Abs(rb.transform.position.x- door.transform.position.x) < compare &&
                Abs(rb.transform.position.y - door.transform.position.y) < compare)
            { 
                win.SetActive(true);
            }
        }
    }
}
