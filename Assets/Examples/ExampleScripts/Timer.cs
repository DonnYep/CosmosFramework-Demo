﻿using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
namespace Cosmos
{
    [DisallowMultipleComponent]
public class Timer : MonoBehaviour {
        [Header("勾选AutoStart则使用StartDelay")]
        [SerializeField] bool autoStart;
        public bool AutoStart { get { return autoStart; } set { autoStart = value; } }
        [SerializeField] float startDelay=1;
        public float StartDelay { get { if (startDelay <= 0) startDelay = 0.1f;return startDelay; } }
        [Header("ExecuteTimerAction默认使用Interval")]
        [SerializeField] float interval=1;
        public float Interval { get { return interval; } set { if (value <= 0.1) interval = 0.1f; else interval = value; } }
        [SerializeField] bool loop=false;
        public bool Loop { get { return loop; } set { loop = value; } }
        [Header("使用随机间隔，属性数值小于Interval")]
        [SerializeField] bool randomInterval=false;
        public bool RandomInterval { get { return randomInterval; } set { randomInterval = value; } }
        [SerializeField] float randomRange;
        public float RandomRange { get { return randomRange; }set { if (randomRange >= Interval) randomRange = Interval;
                else if (randomRange <= 0) randomRange = 0; else randomRange = value; } }
        [SerializeField] UnityEvent action;
        public UnityEvent Action { get { return action; } set { action = value; } }
        Coroutine  tempRoutine;
        private void Start()
        {
            if (autoStart)
                tempRoutine = Utility.Unity.StartCoroutine(EnumAction(StartDelay, () => action.Invoke()));
        }
        private void OnValidate()
        {
            startDelay = Mathf.Clamp(startDelay,0.1f, 1000);
            interval = Mathf.Clamp(interval, 0.1f, 1000);
            randomRange = Mathf.Clamp(randomRange, 0.1f, 1000);
        }
        /// <summary>
        /// 执行的时候可以有延迟
        /// </summary>
        public virtual void ExecuteTimerAction()
        {
            if(!RandomInterval)
            tempRoutine = Utility.Unity.StartCoroutine(EnumAction(Interval, ()=>action.Invoke()));
            else
                tempRoutine = Utility.Unity.StartCoroutine(EnumAction(Interval+ Utility.Unity.Random(-RandomRange, RandomRange), () => action.Invoke()));
        }
        /// <summary>
        /// 立即停止
        /// </summary>
        public virtual void StopTimerAction()
        {
            Utility.Unity.StopCoroutine(tempRoutine);
        }
        IEnumerator EnumAction(float time,Action handler)
        {
            yield return new WaitForSeconds(time);
            handler?.Invoke();
            if(loop)
                tempRoutine = Utility.Unity.StartCoroutine(EnumAction(Interval, () => action.Invoke()));
        }
    }
}