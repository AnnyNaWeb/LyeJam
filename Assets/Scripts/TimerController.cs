using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LyeJam
{
    public class TimerController : MonoBehaviour
    {
        public float totalTime;
        public Text tempo, fase;
        public int acabaTempo;
        public static int faseAtual;
        public static int metaDestruicao;
        bool fimdefase;

        
        private float minutes;
        private static float seconds = 60;
        void Start()
        {
            fimdefase = false;
            faseAtual = 1;
            FaseController();

        }
        void PlayLevel ()
        {
            totalTime += Time.deltaTime;
            minutes = (int)(totalTime / 60);
            seconds = (int)(totalTime % 60);
            tempo.text = minutes.ToString() + " : " + seconds.ToString();

           
        }

        void FaseController()
        {
            switch (faseAtual)
            {
                case 1:
                    metaDestruicao = 1;
                    acabaTempo = 30;
                    break;
                case 2:
                    metaDestruicao = 15;
                    acabaTempo = 50;
                    break;
            }

            

        }
        public static void MetaUpdateDown()
        {
            metaDestruicao = metaDestruicao - 1;
            

        }

        void FimdeJogo()
        {
            if(totalTime >= acabaTempo)
            {
               
                fimdefase = true;
                
                if(metaDestruicao == 0)
                {
                    
                    Debug.Log("Vitoria");
                    //passa pra proxima fase
                    faseAtual++;
                }
                else
                {
                    Debug.Log("Derrota");
                }
            
            }
            if (metaDestruicao == 0)
            {
                Debug.Log("Vitoria");
                fimdefase = true;
               
                
                //passa pra proxima fase
            }
        }

        



        void Update()
        {
            
           
            if (fimdefase)
            {
               
            }
            else
            {
                FaseSelecao();
                PlayLevel();
                FimdeJogo();
            }
            
            
        }
        void FaseSelecao()
        {
            fase.text = "Voce está na fase " + faseAtual + " e deve destruir " + metaDestruicao + " objetos do seu humano.";
        }
    }
}
