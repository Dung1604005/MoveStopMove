using System.Collections.Generic;
using UnityEngine;

public class CharacterEffect : MonoBehaviour
{
   [SerializeField] private List<GameObject> listVfx = new List<GameObject>();


   public void SetActiveVFX(CharacterVFXType characterVFXType, bool active)
    {
        listVfx[(int)characterVFXType].SetActive(active);
    }
}


public enum CharacterVFXType
{
    HEAL,
    LEVEL_UP
}
