using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ColorChangePressing : MonoBehaviour
{
    [SerializeField] Color changeColor;
    private Image _image;
    private Color _normalColor;


    void Start()
    {
        _image = GetComponent<Image>();
        _normalColor = _image.color;
    }

}
