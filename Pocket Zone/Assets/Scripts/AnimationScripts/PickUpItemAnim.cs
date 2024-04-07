using UnityEngine;
using DG.Tweening;

public class PickUpItemAnim : MonoBehaviour
{
    [SerializeField] private float ScaleDuration = 1f;

    public void PickUp()
    {
        Tweener scaleTweener = transform.
            DOScale(Vector3.zero, ScaleDuration);

        scaleTweener.OnComplete(() =>
        {
            gameObject.SetActive(false);
            scaleTweener.Kill();
        });
    }
}
