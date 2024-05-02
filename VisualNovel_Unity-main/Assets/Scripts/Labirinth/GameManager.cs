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
    //текст до введённых игроком команд
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
        basic += "    y++; //шаг вверх \n";
        str.text = before + basic;
        Debug.Log("y++; //шаг вверх");
    }
    public void ClickDown ()
    {
        countstr++;
        basic += "    y--; //шаг вниз "+countstr.ToString()+"\n";
        str.text = before + basic;
        Debug.Log("y--; //шаг вниз");
    }
    public void ClickLeft()
    {
        countstr++;
        basic += "    x--; //шаг влево \n";
        str.text = before + basic;
        Debug.Log("x--; //шаг влево");
    }
    public void ClickRight()
    {
        countstr++;
        basic += "    x++; //шаг вправо \n";
        str.text = before+basic;
        Debug.Log("x++; //шаг вправо");
    }
    public void ClickReset()
    {
        countstr = 0;
        basic = string.Empty;
        str.text = before;
        Debug.Log("заново");
    }
    public void ClickStart()
    {

    }
    public void ChangeScrollCycle()
    {
        if (countcycle.value == 0) countc = 0;
        else countc = countcycle.value + 1; 
    }
    //выскакивающие окошки
    public GameObject Maxstrok, Cycle;
    //доработай эту фигню
    public void ClickCycle()
    {
        if (countstr == 0) return;
        
    }
    public void LettesIsScary(GameObject x) //максимальное кол-во строк кода
    {
        if (countstr > maxstr)
             x.SetActive(false);
    }
    public void Ok(GameObject x)
    {
        if (x != null) x.SetActive(false);
    }
}
