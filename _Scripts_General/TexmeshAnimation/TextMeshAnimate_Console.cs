using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMeshAnimate_Console : MonoBehaviour {

    public TMP_Text m_TextComponent;

    private void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
    }
    private void Start()
    {
        //QualitySettings.antiAliasing = 8;
        AnimateChange();
    }
    public void SetText(string text)
    {
        StopAllCoroutines();
        m_TextComponent.text = text;
        //Debug.Log("Name: " + gameObject.name);
        AnimateChange();
    }
    void AnimateChange()
    {
        StartCoroutine(RevealCharacters(m_TextComponent));
    }

    private void OnDisable()
    {
        StopCoroutine(RevealCharacters(m_TextComponent));
    }

    /// <summary>
    /// Method revealing the text one character at a time.
    /// </summary>
    /// <returns></returns>
    IEnumerator RevealCharacters(TMP_Text textComponent)
    {
        textComponent.ForceMeshUpdate();

        TMP_TextInfo textInfo = textComponent.textInfo;

        int totalVisibleCharacters = textInfo.characterCount; // Get # of Visible Character in text object
        int visibleCount = 0;

        while (true)
        {
            

            if (visibleCount > totalVisibleCharacters)
            {
                yield return new WaitForSeconds(1.0f);
                visibleCount = 0;
            }

            textComponent.maxVisibleCharacters = visibleCount; // How many characters should TextMeshPro display?

            visibleCount += 1;

            yield return new WaitForSeconds(.1f);
        }
    }

}
