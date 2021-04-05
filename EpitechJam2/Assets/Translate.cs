using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    [SerializeField] private bool m_eng = true;
    [SerializeField] private string m_englishText;
    [SerializeField] private string m_frenchText;

    public void SwitchLanguage()
    {
        m_eng = !m_eng;
        this.GetComponent<Text>().text = m_eng ? m_englishText : m_frenchText;
    }
}
