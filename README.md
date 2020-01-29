# Unity Clock
A class to track total play time in Unity.

## What is it for

It is useful for games that need to know how long the player was absent from the game. Regardless of how many times the person has played the game, or has closed it, the clock will always give you the total time since the player has first started playing the the game.

## How to use

Simply create an empty or attach the script to an existing GameObject, then in your script make a reference to the clock like the following:

```csharp
using UnityEngine;
using Shade;

public class Game : MonoBehaviour
{
    public Clock clock;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Total play time of " + clock.time + " seconds.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Total play time of " + clock.time + " seconds.");
    }
}
```

## How it works

It is storing the total play time (Clock_Lifespan) in the PlayerPrefs upon each LateUpdate. Also, when you quit the application, it stores a reference to that moment, so it can convert it back into seconds upon next start and add it to the lifespan.
