using System;
using TMPro;
using UnityEngine;

namespace LyeJam
{
    public class TimerController : MonoBehaviour
    {
        public TextMeshProUGUI tempo, fase;
        
        private float totalTime;
        private bool fimdefase;
        private bool ganhou;
        private bool active = false;
        
        private int metaDestruicao;
        private static int destruicao;
        private int acabaTempo;

        public Action OnWin;
        public Action OnLose;

        public void StartTimer(int timer, int meta)
        {
            metaDestruicao = meta;
            acabaTempo = timer;
            totalTime = 0;
            destruicao = 0;

            active = true;
        }

        public static void AddPoint()
        {
            destruicao += 1;
        }

        void Update()
        {
            if (active && !fimdefase)
            {
                UpdateText();
                CheckTimeAndMeta();
            }
        }

        void UpdateText()
        {
            fase.text = $"{destruicao}/{metaDestruicao}";

            if(!active) return;

            totalTime += Time.deltaTime;
            var rest = acabaTempo - totalTime;
            float minutes = (int)(rest / 60);
            float seconds = (int)(rest % 60);
            tempo.text = minutes.ToString() + " : " + seconds.ToString();
        }

        public void CheckTimeAndMeta()
        {
            if(!active) return;

            if (totalTime >= acabaTempo)
            {
                active = false;
                OnLose?.Invoke();
            }
            if (destruicao == metaDestruicao)
            {
                active = false;
                OnWin?.Invoke();
            }
        }
    }
}
