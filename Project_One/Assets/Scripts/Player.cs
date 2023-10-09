using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
 
    public int playerLevel;
    public static int experiencePoints;
    public int experienceThreshold;
    public int playerBrain;
    public int playerBrawn;
    public int playerHeart;
    public int playerHands;
    public static float playerAttackValue;
    public int playerWounds;
    public bool levelUpAvailable = false;
    public static bool gameOver = false;

    void Start()

    {

        playerLevel = 1;
        experiencePoints = 0;
        experienceThreshold = 50;

        playerBrain = Random.Range(1, 6);
        playerBrawn = Random.Range(1, 6);
        playerHeart = Random.Range(1, 6);
        playerHands = Random.Range(1, 6);

        playerWounds = playerBrawn + playerLevel;
        
        Debug.Log($"Welcome to level {playerLevel}.");
        Debug.Log($"Your brain stat is {playerBrain}.");
        Debug.Log($"Your brawn stat is {playerBrawn}.");
        Debug.Log($"Your heart stat is {playerHeart}.");
        Debug.Log($"Your hands stat is {playerHands}.");
        Debug.Log($"You have {playerWounds} wounds,");

        playerAttackValue = playerBrawn;

    }

    void Update()
    
    {
        if(experiencePoints >= experienceThreshold && levelUpAvailable == false)
        {
            levelUpAvailable = true;
            Debug.Log($"You have enough experience points to level up! Press 'L' to level up!");
        }

        if(Input.GetKeyDown(KeyCode.L) && levelUpAvailable == true)
        {
            playerLevel++;
            experienceThreshold = experienceThreshold + 50;
            experiencePoints = 0;
            playerAttackValue = playerAttackValue * 1.25f;

            Debug.Log($"You have leveled up! You're now level {playerLevel}.");

            levelUpAvailable = false;
        }

        if (playerLevel == 5 && gameOver == false)
        {
            Debug.Log($"You win!");
            gameOver = true;

        }
    }
}   