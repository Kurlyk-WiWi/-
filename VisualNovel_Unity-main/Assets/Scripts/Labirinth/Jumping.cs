using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public enum Command
    {
        brace = 0, up, down, right, left,
        jump_1_up, jump_1_down, jump_1_right, jump_1_left,
        jump_2_up, jump_2_down, jump_2_right, jump_2_left,
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*
    void FixedUpdate()
    {
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
            {
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
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
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
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
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
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
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
                transform.Translate(Vector2.right * 25);
            }
            break;
        case Command.jump_2_left: // хуита
            if (rb.position.x >= now.x - field_scale * 1.5)
            {
                transform.Translate(Vector2.left * s * Time.deltaTime);
                if (lift)
                {
                    jumptspeed -= acceleration;
                    transform.Translate(Vector2.up * jumptspeed * Time.deltaTime);
                    if (rb.position.y >= now.y + field_scale * 0.7)
                    { lift = false; jumptspeed = 0; }
                    Debug.Log("вверх");
                }
                else
                {
                    if (rb.position.y >= now.y)
                    {
                        jumptspeed += acceleration;
                        transform.Translate(Vector2.down * jumptspeed * Time.deltaTime);
                        Debug.Log("вниз");

                    }
                }
            }
            else
            {
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
                transform.Translate(Vector2.down * 49f);
            }
            break;
        case Command.jump_2_right:
            if (rb.position.x <= now.x + field_scale * 1.5)
            {
                transform.Translate(Vector2.right * s * Time.deltaTime);
                if (lift)
                {
                    jumptspeed -= acceleration;
                    transform.Translate(Vector2.up * jumptspeed * Time.deltaTime);
                    if (rb.position.y >= now.y + (field_scale / 2) * 0.7)
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
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
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
                    if (rb.position.x >= now.x + (field_scale / 2) * 0.7)
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
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
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
                    if (rb.position.x <= now.x - (field_scale / 2) * 0.7)
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
                now = rb.position; current++; lift = true; jumptspeed = jumpcanon;
                transform.Translate(Vector2.right * 49f);
            }
            break;
        }
    */
}
