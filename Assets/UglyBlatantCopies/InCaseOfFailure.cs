using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InCaseOfFailure : MonoBehaviour
{
    public Text Word1, Word2;
    public float SwitchColourTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchColours());
    }

    private IEnumerator SwitchColours()
    {
        while(true)
        {
            Word1.color = Color.black;
            Word2.color = Color.white;
            yield return new WaitForSeconds(SwitchColourTime);
            Word1.color = Color.white;
            Word2.color = Color.black;
            yield return new WaitForSeconds(SwitchColourTime);
        }
    }
}
