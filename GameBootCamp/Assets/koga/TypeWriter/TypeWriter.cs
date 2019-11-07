using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



/// <summary>

/// １文字ずつ表示する。タイピング音も鳴らす

/// </summary>

public class TypeWriter : MonoBehaviour

{

    [SerializeField] Text text = default;

    [SerializeField] float span = 0.2f;

    [SerializeField] float delay = 0.5f;

    [SerializeField] bool playOnAwake = true;

    [SerializeField] bool mute = false;



    private AudioSource aud;

    private string sentence;

    private Coroutine coroutine;



    private void Awake()

    {

        aud = GetComponent<AudioSource>();

        sentence = text.text;

        text.text = string.Empty;



        if (playOnAwake) StartTyping();

    }



    public void StartTyping(float delay, float span)

    {

        if (coroutine != null) return;

        coroutine = StartCoroutine(Typing(delay, span));

    }



    // 引数省略版

    public void StartTyping() => StartTyping(this.delay, this.span);

    public void StartTyping(float delay) => StartTyping(delay, this.span);



    private IEnumerator Typing(float delay, float span)

    {

        yield return new WaitForSeconds(delay);



        for (int i = 0; i < sentence.Length; i++)

        {

            text.text += sentence[i];

            if (!mute) aud.Play();

            yield return new WaitForSeconds(span);

        }

    }

}