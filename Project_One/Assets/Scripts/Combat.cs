using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    
    public int roomType;
    public static bool inCombat;
    public int enemyLevel;
    public int enemyBrain;
    public int enemyBrawn;
    public int enemyHeart;
    public int enemyHands;
    public float enemyWounds; 
    public static int randomXPGain;

    void Start()
    {
        
    }


    void Update()
    {

       if (Input.GetKeyDown(KeyCode.W) && inCombat == false && Player.gameOver == false)

       {
            roomType = Random.Range(1, 5);

            if (roomType == 1)
            {
            Debug.Log($"You enter a library.");
            }

            if (roomType == 2)
            {
            Debug.Log($"You enter a study.");
            }

            if (roomType == 3)
            {
            Debug.Log($"You enter a kitchen.");
            }

            if (roomType == 4)
            {
            Combat.inCombat = true;
            Debug.Log($"An enemy appears!");
            
            enemyLevel = Random.Range(1, 4);
            enemyBrain = Random.Range(1, 6);
            enemyBrawn = Random.Range(1, 6);
            enemyHeart = Random.Range(1, 6);
            enemyHands = Random.Range(1, 6);
            enemyWounds = enemyBrawn + enemyLevel;

            Debug.Log($"The enemy has {enemyWounds} Wounds!");
            Debug.Log($"Press 'E' to attack the enemy!");
            }

        }

       if (Input.GetKeyDown(KeyCode.E) && inCombat == true)
            {
                enemyWounds = enemyWounds - Player.playerAttackValue;
                Debug.Log($"You attacked the enemy for {Player.playerAttackValue} damage!");
                Debug.Log($"The enemy has {enemyWounds} Wounds remaining!");
                
                if (enemyWounds <=0)
                {
                    Debug.Log($"You defeated the enemy!");
                    randomXPGain = Random.Range(15, 25);
                    Debug.Log($"You gained {randomXPGain} experience!");
                    Player.experiencePoints = Player.experiencePoints + randomXPGain;
                    Debug.Log($"You now have {Player.experiencePoints} experience points!");
                    inCombat = false;
                }
            }

    }
}
