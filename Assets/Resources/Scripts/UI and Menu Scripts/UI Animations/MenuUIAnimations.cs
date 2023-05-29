using DG.Tweening;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIAnimations : MonoBehaviour
{
    public TransformComponents[] transforms;

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

    private void OnEnable()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].TextColor = fadedMain;
            transforms[i].ShadowColor = fadedShadow;
            transforms[i].OutlineColor = fadedOutline;
        }

        StartCoroutine(SequenceAnimations());
    }

    private void OnDisable()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].TextColor = fadedMain;
            transforms[i].ShadowColor = fadedShadow;
            transforms[i].OutlineColor = fadedOutline;

            transforms[i].transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - 10f);
        }
    }

    private IEnumerator SequenceAnimations()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].transform.DOLocalMoveY(transforms[i].transform.localPosition.y + 10f, duration);
            transforms[i].Text.DOColor(showMain, duration);

            yield return new WaitForSeconds(duration);
        }

        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].ShadowColor = showShadow;
            transforms[i].OutlineColor = showOutline;
        }
    }
}
