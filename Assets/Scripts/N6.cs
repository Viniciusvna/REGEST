﻿using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class N6 : MonoBehaviour
{
    private bool con;
    private string pattern;
    public GameObject inputField; 
    public GameObject textHist;
    public Button btnNext;
    private List<string> historico = new List<string>();

    public void Main(){
        List<string> names = new List<string>(){"abc", "123", "12a", "13464", "a13"};
        List<string> correto = new List<string>(){"123", "13464"};
        List<string> resposta = new List<string>();

        pattern = inputField.GetComponent<Text>().text;

        historico.Add(pattern);

        foreach (string hist in historico){
            textHist.GetComponent<Text>().text = hist;
        }

        foreach (string name in names){
            if (Regex.IsMatch(name, pattern)){
                resposta.Add(name);
            }
        }

        con = resposta.SequenceEqual(correto);
        
        if(con == false){
            textHist.GetComponent<Text>().color = Color.red;
            btnNext.interactable = false;
        }else{
            textHist.GetComponent<Text>().color = Color.green;
            btnNext.interactable = true;
        }
    }
}