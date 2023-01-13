using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBody : MonoBehaviour
{
    private void Update()
    {
        HideCorpse();
    }

    private void HideCorpse()
    {
        if (Stats.instance.DeadAI && Stats.instance.Dragging && Stats.instance.AtCupboard)
        {
            Stats.instance.CanHideBody = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                SoundEffects.PlaySoundEffect("LockerSound");
                Destroy(Stats.instance.DeadAI);
                Stats.instance.Dragging = false;
                Stats.instance.Speed = Stats.instance.MoveSpeed;
            }
        }
        else
        {
            Stats.instance.CanHideBody = false;
        }
    }
}
