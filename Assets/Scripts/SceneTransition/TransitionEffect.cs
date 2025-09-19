using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionEffect : MonoBehaviour
{
    [SerializeField] public Image m_Image;
    [SerializeField] public float m_fSpeed;

    private bool m_bFadeIn = false;
    private bool m_bFadeOut = false;

    private float m_fRed;
    private float m_fGreen;
    private float m_fblue;
    private float m_fAlpha;

    // Start is called before the first frame update
    void Start()
    {
        m_Image = GetComponent<Image>();
        m_fRed = m_Image.color.r;
        m_fGreen = m_Image.color.g;
        m_fblue = m_Image.color.b;
        m_fAlpha = m_Image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_bFadeIn)
        {
            FadeIn();
        }

        if(m_bFadeOut)
        {
            FadeOut();
        }
    }


    public void FadeIn()
    {
        m_fAlpha -= m_fSpeed;
        m_Image.color = new Color(m_fRed, m_fGreen, m_fblue, m_fAlpha);
        if(m_fAlpha <= 0.0f)
        {
            m_bFadeIn = false;
            m_Image.enabled = false;
        }

    }

    public void FadeOut()
    {
        m_Image.enabled = true;
        m_fAlpha += m_fSpeed;
        m_Image.color = new Color(m_fRed, m_fGreen, m_fblue, m_fAlpha);
        if(m_fAlpha >= 1.0f)
        {
            m_bFadeOut = false;
        }
    }


    //Setter関数
    public void SetFadeIn(bool fadein)
    {
        m_bFadeIn = fadein;
    }
    public void SetFadeOut(bool fadeout)
    {
        m_bFadeIn = fadeout;
    }
}
