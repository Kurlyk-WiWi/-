using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text str;
    public Dropdown countcycle; 
    public Dropdown funcarg1, funcarg2;
    //����� �� �������� ������� ������
    public string before= "#include <iostream>\n\nint main()\n{";
    public string basic;
    public int maxstr = 14;
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
    public void ClickUp ()
    {
        countstr++;
        basic += "    y++; //��� ����� \n";
        str.text = before + basic;
        Debug.Log("y++; //��� �����");
    }
    public void ClickDown ()
    {
        countstr++;
        basic += "    y--; //��� ���� "+countstr.ToString()+"\n";
        str.text = before + basic;
        Debug.Log("y--; //��� ����");
    }
    public void ClickLeft()
    {
        countstr++;
        basic += "    x--; //��� ����� \n";
        str.text = before + basic;
        Debug.Log("x--; //��� �����");
    }
    public void ClickRight()
    {
        countstr++;
        basic += "    x++; //��� ������ \n";
        str.text = before+basic;
        Debug.Log("x++; //��� ������");
    }
    public void ClickReset()
    {
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
        if (countcycle.value == 0) countc = 0;
        else countc = countcycle.value + 1; 
    }
    //������������� ������
    public GameObject Maxstrok, Cycle;
    //��������� ��� �����
    public void ClickCycle()
    {
        if (countstr == 0) return;
        
    }
    public void LettesIsScary(GameObject x) //������������ ���-�� ����� ����
    {
        if (countstr > maxstr)
             x.SetActive(false);
    }
    public void Ok(GameObject x)
    {
        if (x != null) x.SetActive(false);
    }
}
