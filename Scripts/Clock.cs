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
            // Initialize value
            if (! PlayerPrefs.HasKey("Shade_Clock_Lifespan"))
            {
                PlayerPrefs.SetFloat("Shade_Clock_Lifespan", Time.fixedTime);
            }
            
            DateTime now = DateTime.Now;
            DateTime then = DateTime.Now; // Will reference to last seen time

            if (PlayerPrefs.HasKey("Shade_Clock_LastSeen"))
            {
                // Grab the old time from the player prefs as a long
                long temp = Convert.ToInt64(PlayerPrefs.GetString("Shade_Clock_LastSeen"));

                // Convert the old time from binary to a DataTime variable
                then = DateTime.FromBinary(temp);
            }

            TimeSpan difference = now.Subtract(then);

            time = PlayerPrefs.GetFloat("Shade_Clock_Lifespan") + Convert.ToSingle(difference.TotalSeconds);

            PlayerPrefs.SetFloat("Shade_Clock_Lifespan", time);
        }

        void Update()
        {
            time = PlayerPrefs.GetFloat("Shade_Clock_Lifespan") + Time.fixedTime;

            PlayerPrefs.SetFloat("Shade_Clock_Lifespan", time);
        }

        void OnApplicationQuit()
        {   
            DateTime then = DateTime.Now;

            // Grab the old time from the player prefs as a long
            long temp = Convert.ToInt64(System.DateTime.Now.ToBinary().ToString());

            // Convert the old time from binary to a DataTime variable
            then = DateTime.FromBinary(temp);

            PlayerPrefs.SetString("Shade_Clock_LastSeen", System.DateTime.Now.ToBinary().ToString());
        }
    }
}
