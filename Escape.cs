using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.Globalization;
using UnityEditor;

public class Escape : MonoBehaviour
{
    
    public void Quit()
    {
        
          Application.Quit();    // ������� ����������
          UnityEditor.EditorApplication.isPlaying = false;
    }
}

