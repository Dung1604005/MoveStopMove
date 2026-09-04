using System;
using UnityEngine;

public static class GameConfig
{
    //ANIM CHO CHARACTER

    public const String ANIM_IDLE = "idle";

    public const String ANIM_MOVING = "move";

    public const String ANIM_DEAD= "dead";

    public const String ANIM_ATTACK = "attack";

    public const String CHARACTER_TAG = "Character";

    public const String CHARACTER_LAYER = "Character";

    public const String OBSTACLE_TAG = "Obstacle";

    public const String OBSTACLe_LAYER = "Obstacle";

    public static readonly String[] LIST_NAME = {"Dung", "Tan", "Huy", "Chuong", "Giang", "Hao", "Khanh", "Anh", "Quan", "Dat"};

    //Data save

    public const String PLAYERDATA_KEY = "Playerdata";
    

    // Stat chung

    public const float BASE_EXP = 100f;

    public const float EXP_GROWTHRATE = 1.1f;

    public const float EXP_GAIN_PER_LEVEL = 67f;

    public const float SIZE_GROWTHRATE = 0.25f;

    public const float HEALTH_GROWTH = 15f;

    public const float RANGE_GROWTH = 1.4f;

    public const float ATK_GROWTH = 5f;

    public const float MAX_SIZE = 2f;

    public const float MAX_RANGE = 10f;
    //Other


    public const int TOTAL_SKINTYPE = 2;




    

}
