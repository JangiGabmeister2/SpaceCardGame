using DG.Tweening;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIAnimations : MonoBehaviour
{
    [System.Serializable]
    public struct TextShit
    {
        public Transform transform;
        public Text text;
        public Shadow shadow;
        public Outline outline;
    }
    //[SerializeField] private List<Transform> tranforms = new List<Transform>();
    public TextShit[] transforms;

    [Space(5), Header("Main Colour")]
    public Color fadedMain;
    public Color showMain;
    [Space(5), Header("Shadow Colour")]
    public Color fadedShadow;
    public Color showShadow;
    [Space(5), Header("Outline Colour")]
    public Color fadedOutline;
    public Color showOutline;
    [Space(5), Header("Time")]
    public float duration;

    private void Start()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].text.color = fadedMain;
            transforms[i].shadow.effectColor = fadedShadow;
            transforms[i].outline.effectColor = fadedOutline;
        }

        StartCoroutine(SequenceAnimations());
    }

    private IEnumerator SequenceAnimations()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].transform.DOLocalMoveY(transforms[i].transform.localPosition.y + 10f, duration);
            transforms[i].text.DOColor(showMain, duration);

            yield return new WaitForSeconds(duration);
        }

        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].shadow.effectColor = showShadow;
            transforms[i].outline.effectColor = showOutline;
        }
    }
}
