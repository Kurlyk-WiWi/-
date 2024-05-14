using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Timeline;

namespace Labirinth
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private float s;
        public enum Command
        {brace=0, up, down, right, left, cycle, jump}
        public Command[] commands;
        public Rigidbody2D rb;
        private Vector2 moveVelocity;
        public  Rigidbody2D field;
        public float field_scale;
        public Human(Command[] commands)
        {
            this.commands = commands;
        }
        public Human()
        {
            commands = new Command[0];
        }
        // Start is called before the first frame update
        void Start()
        {
            rb=GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
           
        }
        private void FixedUpdate()
        {
            if (rb.position.x >= field.position.x-field_scale)
                transform.Translate(Vector2.left * s * Time.deltaTime);
        }
    }
}
