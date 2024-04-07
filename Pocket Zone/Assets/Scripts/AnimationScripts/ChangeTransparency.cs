using UnityEngine;
using DG.Tweening;

public class ChangeTransparency : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    private Material _material;
    private Tweener _tweener;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        _tweener = _material.DOFade(0f, duration).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        _tweener.Kill();
        _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, 1f);
    }
}
