using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Labirinth
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Human human;
        public BoxCollider2D player;
        public TMP_Text str;
        public TMP_Dropdown countcycle;
        public TMP_Dropdown funcarg1, funcarg2;
        public BoxCollider2D field;
        //текст до введённых игроком команд
        public string basic;
        public int maxstr = 13, maxcode;
        public int countstr, countc;
        public int func1, func2;
        public List <Command> commands;
        public List<Command> cycle;
        public GameObject door;
        public Level leveldisiner;
        // Start is called before the first frame update
        public string rules;
        void Start()
        {
            basic = ""; countstr = 0;
            countc = 0; 
            func1 = 0; func2 = 0;
            commands = new List <Command>();
            cycle = new List <Command>();
            string rules ="Цель игры: добраться до двери. Пишите сюда команды для Юрия с помощью кнопок слева.\n" +
                "Следите за тем, чтобы Юрий не ходил в стены коридора или в баги.\n" +
                "Юрий пойдёт по заданному маршруту, если нажать кнопку запуск. Чтобы переписать маршрут, используйте кнопку сброс.";
            str.text= rules;
        }
        public void ClickUp()
        {
            if (incycle)
            {
                if (countc == 4) return;
                if (countc == 3)
                    cyclebasic += "        y++; //шаг вверх";
                else cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                countc++;
                cycle.Add(Command.up);
                return;
            }
            if (countstr >= maxstr)
            { Maxstrok.SetActive(true); return; }
            countstr++;
            basic += "    y++; //шаг вверх \n";
            str.text = basic;
            commands.Add(Command.up);
        }
        public void ClickDown()
        {
            if (incycle)
            {
                if (countc == 4) return;
                if (countc == 3)
                    cyclebasic += "        y++; //шаг вверх ";
                else cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                countc++;
                cycle.Add(Command.down);
                return;
            }
            if (countstr >= maxstr)
            { Maxstrok.SetActive(true); return; }
            countstr++;
            basic += "    y--; //шаг вниз\n";
            str.text = basic;
            commands.Add(Command.down);
        }
        public void ClickLeft()
        {
            if (incycle)
            {
                if (countc == 4) return;
                if (countc == 3)
                    cyclebasic += "        y++; //шаг вверх ";
                else cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                countc++;
                cycle.Add(Command.left);
                return;
            }
            if (countstr >= maxstr)
            {
                Maxstrok.SetActive(true); return;
            }
            countstr++;
            basic += "    x--; //шаг влево \n";
            str.text = basic;
            commands.Add(Command.left);
        }
        public void ClickRight()
        {
            if (incycle)
            {
                cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                cycle.Add(Command.right);
                return;
            }
            if (countstr >= maxstr)
            {
                Maxstrok.SetActive(true); return;
            }
            countstr++;
            basic += "    x++; //шаг вправо \n";
            str.text = basic;
            commands.Add(Command.right);
        }
        public void ClickReset()
        {
            if (incycle) return;
            countstr = 0;
            basic = string.Empty;
            str.text = basic;
            Debug.Log("заново");
            commands.Clear();
        }
        public void ClickStart()
        {
            human.SetCommands(commands);
            commands.Clear();
        }
        public void ChangeScrollCycle()
        {
            countc = countcycle.value + 1;
            cyclebefore = "for (int i=0; i<" + (countc - 1).ToString() + "; i++){\n";
            if (Cycle.activeSelf) CycleStr.text = cyclebefore + cyclebasic + "}";
        }
        public void ChangeScrollFunc1()
        {
            func1 = funcarg1.value;
        }
        public void ChangeScrollFunc2()
        {
            func2 = funcarg2.value;
        }
        public void ClickFunc()
        {
            if (func1 < 1 || func2 < 1) { Debug.Log("fffffffff"); return; }
            string a = "";
            switch (func1)
            {
                case 1: a = "вперёд"; break;
                case 2: a = "назад"; break;
                case 3: a = "вправо"; break;
                case 4: a = "влево"; break;
                default: a = "ошибка"; break;
            }
            int b=4+(func2-1)*4+func1;
            if (incycle)
            {
                cyclebasic += "    jump (" + a + ',' + func2.ToString() + "); //функция прыжка\n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                cycle.Add(ToCommand(b));
                return;
            }
            basic += "    jump (" + a + ',' + func2.ToString() + "); //функция прыжка\n";
            commands.Add(ToCommand(b)); 
            str.text = basic;
        }
        Command ToCommand (int a)
        {
            switch (a)
            {
                case 5: return Command.jump_1_up;
                case 6: return Command.jump_1_down;
                case 7: return Command.jump_1_right;
                case 8: return Command.jump_1_left;
                case 9: return Command.jump_2_up;
                case 10: return Command.jump_2_down;
                case 11: return Command.jump_2_right;
                case 12: return Command.jump_2_left;
                default: return Command.brace;
            }
        }
        //выскакивающие окошки
        public GameObject Maxstrok, Cycle;
        public TMP_Text CycleStr;
        public string cyclebefore, cyclebasic;
        public bool incycle = false;
        public void ClickCycle()
        {
            Cycle.SetActive(true);
            cyclebefore = "for (int i=0; i<" + (countc - 1).ToString() + "; i++){\n";
            CycleStr.text = cyclebefore + "\n    }";
            incycle = true;
        }
        public void AddCycle()
        {
            if (countc <= 1) return;
            basic += "    " + cyclebefore + cyclebasic + "    }//цикл\n";
            str.text = basic;
            cyclebasic = string.Empty;
            incycle = false;
            Cycle.SetActive(false);
            for(int i = 0; i < countc; i++)
            {
                commands.AddRange(cycle);
            }
            cycle.Clear();
            countc = 0;
        }
        public void Ok(GameObject x)
        {
            if (x.activeSelf) x.SetActive(false);
        }
        public void Func_Ok(GameObject x, Button a)
        {
            if (x.activeSelf) x.SetActive(false);
            else
            { x.SetActive(true); a.interactable = false; }
        }
    }
}
