using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� : https://moondongjun.tistory.com/38
/// </summary>
public static class AnimatorEventExtension
{
    private static AnimatorEventReceiver AttachReceiver(ref Animator animator)
    {
        AnimatorEventReceiver   receiver = animator.gameObject.GetComponent<AnimatorEventReceiver>();
        if(receiver == null)    receiver = animator.gameObject.AddComponent<AnimatorEventReceiver>();
        return receiver;
    }

    public static void SetInteger(this Animator animator, string name, int value, Action onFinished)
    {
        animator.SetInteger(name, value);
        AttachReceiver(ref animator).OnStateEnd(onFinished);
    }

    public static void SetFloat(this Animator animator, string name, float value, Action onFinished)
    {
        animator.SetFloat(name, value);
        AttachReceiver(ref animator).OnStateEnd(onFinished);
    }

    public static void SetBool(this Animator animator, string name, bool value, Action onFinished)
    {
        animator.SetBool(name, value);
        AttachReceiver(ref animator).OnStateEnd(onFinished);
    }

    public static void SetTrigger(this Animator animator, string name, Action onFinished)
    {
        animator.SetTrigger(name);
        AttachReceiver(ref animator).OnStateEnd(onFinished);
    }

    public static void SetCrossFade(this Animator animator, string name, float value, Action onFinished)
    {
        animator.CrossFade(name, value);
        AttachReceiver(ref animator).OnStateEnd(onFinished);
    }
}

[RequireComponent(typeof(Animator))]
public class AnimatorEventReceiver : MonoBehaviour
{
    [HideInInspector] public List<AnimationClip> animationClips = new List<AnimationClip>();

    private Animator animator = null;
    private Dictionary<string, List<Action>> _startEvents   = new Dictionary<string, List<Action>>();
    private Dictionary<string, List<Action>> _endEvents     = new Dictionary<string, List<Action>>();

    private Coroutine _coroutine = null;
    private bool _isPlayingAnimator = false;

    public void OnStateEnd(Action onFinished)
    {
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(OnStateEndCheck(onFinished));
    }

    public IEnumerator OnStateEndCheck(Action onFinished)
    {
        _isPlayingAnimator = true;

        //while (true)
        //{
        //    yield return new WaitForEndOfFrame();
        //    if (_isPlayingAnimator)
        //    {
        //        // ���� �ִϸ��̼� Ŭ���� ����Ǵ��� 1������ �� ��ٸ�
        //        yield return new WaitForEndOfFrame();

        //        if (_isPlayingAnimator == false) 
        //            break;
        //    }
        //}

        yield return new WaitUntil(() => _isPlayingAnimator == false);

        onFinished?.Invoke();
    }

    public void Awake()
    {
        // �ִϸ����� ���� �ִ� ��� �ִϸ��̼� Ŭ���� ���۰� ���� �̺�Ʈ�� ����
        if (animator == null)
            animator = GetComponent<Animator>();
        foreach(AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            animationClips.Add(clip);

            // start event
            AnimationEvent animationStartEvent = new AnimationEvent();
            animationStartEvent.time = 0;
            animationStartEvent.functionName = Constants.AnimationStartEventFunctionName;
            animationStartEvent.stringParameter = clip.name;
            clip.AddEvent(animationStartEvent);

            // end event
            AnimationEvent animationEndEvent = new AnimationEvent();
            animationEndEvent.time = clip.length;
            animationEndEvent.functionName = Constants.AnimationEndEventFunctionName;
            animationEndEvent.stringParameter = clip.name;
            clip.AddEvent(animationEndEvent);
        }
    }

    // �ִϸ��̼� Ŭ�� ���� �̺�Ʈ
    private void AnimationStartHandler(string name)
    {
        if(_startEvents.TryGetValue(name, out var actions))
        {
            foreach (var action in actions)
                action?.Invoke();

            actions.Clear();
        }

        _isPlayingAnimator = true;
    }

    // �ִϸ��̼� Ŭ�� ���� �̺�Ʈ
    private void AnimationEndHandler(string name)
    {
        if(_endEvents.TryGetValue(name,out var actions))
        {
            foreach(var action in actions)
                action?.Invoke();

            actions.Clear();
        }

        _isPlayingAnimator = false;
    }
}
