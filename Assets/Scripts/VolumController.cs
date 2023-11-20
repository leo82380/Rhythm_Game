using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumController : MonoBehaviour
{
    private Volume volume;
    private Vignette vignette;

    private void Awake()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
    }
    public IEnumerator ColorChange()
    {
        if (UIManager.Instance.JudgeType == JudgeType.Perfect)
        {
            vignette.color.value = new Color(0, 0.04362191f, 0.3113208f);
            yield return new WaitForSeconds(0.5f);
            vignette.color.value = Color.black;
            UIManager.Instance.JudgeType = JudgeType.None;
        }
        else if (UIManager.Instance.JudgeType == JudgeType.Miss)
        {
            vignette.color.value = new Color(0.3098039f, 0.009209858f, 0);
            yield return new WaitForSeconds(0.5f);
            vignette.color.value = Color.black;
            UIManager.Instance.JudgeType = JudgeType.None;
        }
        else
        {
            vignette.color.value = Color.black;
        }
    }
}
