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
            if (! PlayerPrefs.HasKey("Clock_Lifespan"))
            {
                PlayerPrefs.SetFloat("Clock_Lifespan", Time.time);
            }
            
            DateTime now = DateTime.Now;
            DateTime then = DateTime.Now; // Will reference to last seen time

            if (PlayerPrefs.HasKey("Clock_LastSeen"))
            {
                // Grab the old time from the player prefs as a long
                long temp = Convert.ToInt64(PlayerPrefs.GetString("Clock_LastSeen"));

                // Convert the old time from binary to a DataTime variable
                then = DateTime.FromBinary(temp);
            }

            //Use the Subtract method and store the result as a timespan variable
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
