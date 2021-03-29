using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JMC : MonoBehaviour
{

    protected static Prototype1.GameManager _GM1 { get { return Prototype1.GameManager.instance; } }
    protected static Prototype1.UIManager _UI1 { get { return Prototype1.UIManager.instance; } }
    protected static Prototype1.PlayerController _PC1 { get { return Prototype1.PlayerController.instance; } }

    protected static Prototype2.SpawnManager _SM2 { get { return Prototype2.SpawnManager.instance; } }
    //protected static Prototype2.GameManager _GM2 { get { return Prototype2.GameManager.instance; } }

    protected static Prototype3.SpawnManager _SM3 { get { return Prototype3.SpawnManager.instance; } }




    /// <summary>
    /// Use this to check if we should call Game Over
    /// </summary>
    /// <param name="_lives"> The players current lives </param>
    /// <returns> If we are at Game Over or not </returns>
    public bool IsGameOver(int _lives)
    {
        return _lives == 0;
    }

    /// <summary>
    /// Works out the change in percentage between two scores
    /// </summary>
    /// <param name="_score1"> The original score </param>
    /// <param name="_score2"> The new score </param>
    /// <returns> The percentage between two scores </returns>
    public float PercentageCheck (int _score1, int _score2)
    {
        float change = _score2 - _score1;
        return change / _score1 * 100;
    }

    /// <summary>
    /// Fades a UI canvas in or out
    /// </summary>
    /// <param name="_cvg"> The canvas group to fade </param>
    /// <param name="_toValue"> The value to fade to </param>
    /// <param name="_duration"> The duration of the fade </param>
    public void FadeCanvas(CanvasGroup _cvg, float _toValue, float _duration)
    {
        _cvg.DOFade(_toValue, _duration);
    }
}

public class Singleton<T> : JMC where T : JMC
{
    private static T instance_;
    public static T instance
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>(); // AwakeAwake gets gets called called inside AddComponent
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this as T;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}