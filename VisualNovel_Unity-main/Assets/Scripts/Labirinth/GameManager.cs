using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text str;
    public TMP_Dropdown countcycle;
    public TMP_Dropdown funcarg1, funcarg2;
    //����� �� �������� ������� ������
    public string before = "#include <iostream>\nint main()\n{";
    public string basic;
    public int maxstr = 13;
    public int countstr, countc;
    // Start is called before the first frame update
    void Start()
    {
        str.text = before;
        basic = ""; countstr = 0;
        countc = 0;
    }
    void Update()
    {

    }
    public void ClickUp()
    {
        if(incycle)
        {
            cyclebasic += "        y++; //��� ����� \n";
            CycleStr.text = cyclebefore + cyclebasic+"    }";
            return;
        }
        if (countstr >= maxstr)
        { Maxstrok.SetActive(true); return; }
        countstr++;
        basic += "    y++; //��� ����� \n";
        str.text = before + basic;
        Debug.Log("y++; //��� �����");
    }
    public void ClickDown()
    {
        if (incycle)
        {
            cyclebasic += "        y++; //��� ����� \n";
            CycleStr.text = cyclebefore + cyclebasic + "    }";
            return;
        }
        if (countstr >= maxstr)
        { Maxstrok.SetActive(true); return; }
        countstr++;
        basic += "    y--; //��� ���� " + countstr.ToString() + "\n";
        str.text = before + basic;
        Debug.Log("y--; //��� ����");
    }
    public void ClickLeft()
    {
        if (incycle)
        {
            cyclebasic += "        y++; //��� ����� \n";
            CycleStr.text = cyclebefore + cyclebasic + "    }";
            return;
        }
        if (countstr >= maxstr)
        {
            Maxstrok.SetActive(true); return;
        }
        countstr++;
        basic += "    x--; //��� ����� \n";
        str.text = before + basic;
        Debug.Log("x--; //��� �����");
    }
    public void ClickRight()
    {
        if (incycle)
        {
            cyclebasic += "        y++; //��� ����� \n";
            CycleStr.text = cyclebefore + cyclebasic + "    }";
            return;
        }
        if (countstr >= maxstr)
        {
            Maxstrok.SetActive(true); return;
        }
        countstr++;
        basic += "    x++; //��� ������ \n";
        str.text = before + basic;
        Debug.Log("x++; //��� ������");
    }
    public void ClickReset()
    {
        if (incycle) return;
        countstr = 0;
        basic = string.Empty;
        str.text = before;
        Debug.Log("������");
    }
    public void ClickStart()
    {

    }
    public void ChangeScrollCycle()
    {
        countc = countcycle.value + 1;
        cyclebefore = "for (int i=0; i<" + (countc-1).ToString() + "; i++){\n";
        if (Cycle.activeSelf) CycleStr.text = cyclebefore+cyclebasic+"}";
    }
    //������������� ������
    public GameObject Maxstrok, Cycle;
    public TMP_Text CycleStr;
    public string cyclebefore, cyclebasic;
    public bool incycle=false;
    //��������� ��� �����
    public void ClickCycle()
    {
        Cycle.SetActive(true);
        cyclebefore = "for (int i=0; i<" + (countc-1).ToString() + "; i++){\n";
        CycleStr.text= cyclebefore+"\n    }";
        incycle = true;
    }
    public void AddCycle()
    {
        if (countc <= 1) return;
        basic += "    " + cyclebefore + cyclebasic + "    }";
        str.text = before + basic;
        cyclebasic = string.Empty;
        incycle = false;
        Cycle.SetActive(false);
    }
    public void Ok(GameObject x)
    {
        if (x != null) x.SetActive(false);
    }
}
