

using Const;
using Controllers.Interfaces;
using GameContext.Interfaces;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public sealed class GameContext : MonoBehaviour, IGameContext
    {
        [ShowInInspector]
        [ReadOnly]
        [Space]
        private readonly List<object> listeners = new();
        [ShowInInspector]
        [ReadOnly]
        [Space]
        private readonly List<object> services = new();

        public T GetService<T>()
        {
            foreach(var service in services)
            {
                if(service is T result)
                {
                    return result;
                }
            }
            throw new Exception($"Service of type {typeof(T)} is not found!");
        }

        [Button]
        public void ConstructGame()
        {
            foreach(var listener in listeners)
            {
                if(listener is IConstructListener constructListener)
                {
                    constructListener.Construct(this);
                }
            }
        }

        [Button]
        public void StartGame()
        {
            foreach(var listener in listeners)
            {
                if(listener is IStartGameListener startListener)
                {
                    startListener.OnStartGame();
                }
            }
        }

        [Button]
        public void FinishGame(GameFinishType result)
        {
            foreach(var listener in listeners)
            {
                if(listener is IFinishGameListener finishListener)
                {
                    finishListener.OnFinishGame();
                }

                if(listener is IFinishGameResultListener finishResultListener)
                {
                    finishResultListener.OnFinishResultGame(result);
                }
            }
        }


        public void AddListener(object listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(object listener)
        {
            listeners.Remove(listener);
        }

        public void AddService(object service)
        {
            services.Add(service);
        }
        public void RemoveService(object service)
        {
            services.Remove(service);
        }


        [Button]
        public void PauseGame()
        {
            foreach(var listener in listeners)
            {
                if(listener is IPauseGameListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }
        }

        [Button]
        public void ResumeGame()
        {
            foreach(var listener in listeners)
            {
                if(listener is IResumeGameListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }
        }

    }
}
