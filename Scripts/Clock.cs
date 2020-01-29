using System;
using UnityEngine;

namespace Shade
{
    public class Clock : MonoBehaviour
    {
        [HideInInspector]
        public float time = 0f;

        void Start()
        {
            if (! PlayerPrefs.HasKey("Clock_Lifespan"))
            {
                PlayerPrefs.SetFloat("Clock_Lifespan", Time.time);
            }
            
            DateTime now = DateTime.Now;
            DateTime then = DateTime.Now; // Reference to last seen

            if (PlayerPrefs.HasKey("Clock_LastSeen"))
            {
                long temp = Convert.ToInt64(PlayerPrefs.GetString("Clock_LastSeen"));
                then = DateTime.FromBinary(temp);
            }

            TimeSpan difference = now.Subtract(then);

            time = PlayerPrefs.GetFloat("Clock_Lifespan") + Convert.ToSingle(difference.TotalSeconds);

            PlayerPrefs.SetFloat("Clock_Lifespan", time);
        }

        void LateUpdate()
        {
            time = PlayerPrefs.GetFloat("Clock_Lifespan") + Time.time;

            PlayerPrefs.SetFloat("Clock_Lifespan", time);
        }

        void OnApplicationQuit()
        {   
            PlayerPrefs.SetString("Clock_LastSeen", System.DateTime.Now.ToBinary().ToString());
        }
    }
}
