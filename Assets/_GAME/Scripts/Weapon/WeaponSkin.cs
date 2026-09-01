using UnityEngine;

public class WeaponSkin : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    public void ChangeSkin(WeaponSkinData weaponSkinData)
    {
        if (weaponSkinData.GetSkinMat() == null)
        {
            Debug.Log("THIS SKIN DONT HAVE SKIN MAT");
            return;
        }
        Material[] newMats = new Material[renderer.sharedMaterials.Length];
        for (int i = 0; i < newMats.Length; i++)
        {
            newMats[i] = weaponSkinData.GetSkinMat();
        }
        renderer.materials = newMats;
    }
}
