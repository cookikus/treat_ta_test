using UnityEngine;

public class StateSoundBehaviour : StateMachineBehaviour
{
    public AudioClip stateSound;
    [Range(0, 1)] public float volume = 0.5f;

    public bool loopSound = true;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioSource audio = animator.GetComponent<AudioSource>();

        if (audio != null && stateSound != null)
        {
            audio.clip = stateSound;
            audio.volume = volume;
            audio.loop = loopSound;
            audio.Play();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AudioSource audio = animator.GetComponent<AudioSource>();
        if (audio != null && loopSound)
        {
            audio.Stop();
        }
    }
}