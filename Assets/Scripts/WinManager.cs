using UnityEngine;
using System.Collections;

public class WinManager : MonoBehaviour
{
    [Header("Windows")]
    public GameObject winWindow;
    public Animator buttonsAnimator;
    public Animator barkButtonAnimator;
    public GameObject rewardWindow;

    [Header("Effects")]
    public ParticleSystem confettiEffect;
    public ParticleSystem diceInEffect;
    public ParticleSystem generalGlowEffect;

    [Header("Timings")]
    public float levitationDuration = 2.5f;
    public float suctionDuration = 1.0f;

    private int tricksDone = 0;
    private const int requiredTricks = 3;

    public void OnTrickFinished()
    {
        tricksDone++;

        if (tricksDone >= requiredTricks)
        {
            if (buttonsAnimator != null)
                buttonsAnimator.SetTrigger("HideButtons");

            if (barkButtonAnimator != null)
                barkButtonAnimator.SetTrigger("HideButtons");

            winWindow.SetActive(true);
        }
    }

    public void ClaimReward()
    {
        winWindow.SetActive(false);
        if (rewardWindow != null) rewardWindow.SetActive(true);
        if (confettiEffect != null) confettiEffect.Play();
        tricksDone = 0;
    }

    public void CloseRewardAndStartDice()
    {
        if (rewardWindow != null)
            rewardWindow.SetActive(false);

        StartCoroutine(DiceSequenceRoutine());
    }

    private IEnumerator DiceSequenceRoutine()
    {
        if (diceInEffect != null)
        {
            diceInEffect.gameObject.SetActive(true);
            diceInEffect.Play();
        }

        yield return new WaitForSeconds(0.05f);
        if (generalGlowEffect != null)
        {
            generalGlowEffect.gameObject.SetActive(true);
            generalGlowEffect.Play();
        }

        yield return new WaitForSeconds(levitationDuration + suctionDuration);

        if (generalGlowEffect != null)
            generalGlowEffect.gameObject.SetActive(false);

    }
}