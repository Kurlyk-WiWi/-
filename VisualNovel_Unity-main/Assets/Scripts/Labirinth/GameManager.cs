using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Labirinth
{
    public class GameManager : MonoBehaviour
    {
        public TMP_Text str;
        public TMP_Dropdown countcycle;
        public TMP_Dropdown funcarg1, funcarg2;
        public Rigidbody2D human;
        //текст до введённых игроком команд
        public string basic;
        public int maxstr = 13;
        public int countstr, countc;
        public int func1, func2;
        // Start is called before the first frame update
        void Start()
        {
            basic = ""; countstr = 0;
            countc = 0;
            func1 = 0; func2 = 0;
        }
        void Update()
        {

        }
        public void ClickUp()
        {
            if (incycle)
            {
                cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                return;
            }
            if (countstr >= maxstr)
            { Maxstrok.SetActive(true); return; }
            countstr++;
            basic += "    y++; //шаг вверх \n";
            str.text = basic;
            Debug.Log("y++; //шаг вверх");
        }
        public void ClickDown()
        {
            if (incycle)
            {
                cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                return;
            }
            if (countstr >= maxstr)
            { Maxstrok.SetActive(true); return; }
            countstr++;
            basic += "    y--; //шаг вниз " + countstr.ToString() + "\n";
            str.text = basic;
            Debug.Log("y--; //шаг вниз");
        }
        public void ClickLeft()
        {
            if (incycle)
            {
                cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                return;
            }
            if (countstr >= maxstr)
            {
                Maxstrok.SetActive(true); return;
            }
            countstr++;
            basic += "    x--; //шаг влево \n";
            str.text = basic;
            Debug.Log("x--; //шаг влево");
        }
        public void ClickRight()
        {
            if (incycle)
            {
                cyclebasic += "        y++; //шаг вверх \n";
                CycleStr.text = cyclebefore + cyclebasic + "    }";
                return;
            }
            if (countstr >= maxstr)
            {
                Maxstrok.SetActive(true); return;
            }
            countstr++;
            basic += "    x++; //шаг вправо \n";
            str.text = basic;
            Debug.Log("x++; //шаг вправо");
        }
        public void ClickReset()
        {
            if (incycle) return;
            countstr = 0;
            basic = string.Empty;
            str.text = basic;
            Debug.Log("заново");
        }
        public void ClickStart()
        {

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
            Debug.Log("func1=" + func1.ToString());
        }
        public void ChangeScrollFunc2()
        {
            func2 = funcarg2.value;
            Debug.Log("func2=" + func2.ToString());
        }
        //надо пофиксить буквы "ф" и "ц" в выводимом слове "функция"
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
            basic += "    jump (" + a + ',' + func2.ToString() + ") //функция прыжка";
            Debug.Log("функция прыжка");
            str.text = basic;
        }
        //выскакивающие окошки
        public GameObject Maxstrok, Cycle;
        public TMP_Text CycleStr;
        public string cyclebefore, cyclebasic;
        public bool incycle = false;
        //доработай эту фигню
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
            basic += "    " + cyclebefore + cyclebasic + "    }";
            str.text = basic;
            cyclebasic = string.Empty;
            incycle = false;
            Cycle.SetActive(false);
        }
        public void Ok(GameObject x)
        {
            if (x != null) x.SetActive(false);
        }
    }
}
