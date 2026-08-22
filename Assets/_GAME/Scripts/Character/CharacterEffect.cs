using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterEffect : MonoBehaviour
{
   [SerializeField] private List<EffectVFX> listVfx = new List<EffectVFX>();


   public void SetActiveVFX(CharacterVFXType characterVFXType, bool active)
    {
        TurnOffAllEffect();
        listVfx[(int)characterVFXType].SetActive(active);

        if (active)
        {
            listVfx[(int)characterVFXType].OnInit();
        }
    }

    public void TurnOffAllEffect()
    {
        foreach(EffectVFX effectVFX in listVfx)
        {
            effectVFX.SetActive(false);
        }
    }
}


public enum CharacterVFXType
{
    HEAL,
    LEVEL_UP
}
