using UnityEngine;
using System.Collections;

public static class GameHelper
{
    private static int[] requiredExperiencePerLevel;

    static GameHelper()
    {
        // Calculate and init each experience required per level.
        GameHelper.requiredExperiencePerLevel = new int[99];
        for (int i = 0; i < 99; i++)
        {
            int value = (i * i + i + 3) * 4;
            GameHelper.requiredExperiencePerLevel[i] = value;
        }
    }

    public static int ConvertExpToLevel (int exp)
    {
        int level = 1;

        for (int i = 0; i < GameHelper.requiredExperiencePerLevel.Length; i++)
        {
            if (exp >= GameHelper.requiredExperiencePerLevel[i])
            {
                exp -= GameHelper.requiredExperiencePerLevel[i];
                level++;
            }
            else
            {
                break;
            }
        }

        return level;
    }

    public static int GetInventoryCharacterLevelExperience(int exp)
    {
        for (int i = 0; i < GameHelper.requiredExperiencePerLevel.Length; i++)
        {
            if (exp >= GameHelper.requiredExperiencePerLevel[i])
            {
                exp -= GameHelper.requiredExperiencePerLevel[i];
            }
            else
            {
                break;
            }
        }

        return exp;
    }

    public static int GetInventoryCharacterLevelRequiredExperience(int exp, int level)
    {
        return GameHelper.requiredExperiencePerLevel[level - 1];
    }
}
