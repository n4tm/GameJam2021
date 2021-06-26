using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CreateMagic : MonoBehaviour
{
    private GameObject NewSpell;
    public void cast(GameObject magictype, Vector3 castPoint)
    {
        NewSpell = Instantiate(magictype, castPoint, quaternion.identity);
        NewSpell.transform.localScale = Vector3.one * 2;
    }
}
