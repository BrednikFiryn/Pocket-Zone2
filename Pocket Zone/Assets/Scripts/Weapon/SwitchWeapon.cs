using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] weaponBasicActiveIcon;
    [SerializeField] private GameObject[] weaponAuxiliaryActiveIcon;
    private PlayerWeapon _playerWeapon;

    private void Start()
    {
        _playerWeapon = FindObjectOfType<PlayerWeapon>();
    }

    public void Swith()
    {
      if (IWeapon.activeBasic)
         {
            _playerWeapon.weaponInvenory[1].SetActive(true);
            _playerWeapon.weaponInvenory[0].SetActive(false);
            AuxiliaryActive();
            IWeapon.activeBasic = false;
        }

      else if (!IWeapon.activeBasic)
        {
            _playerWeapon.weaponInvenory[1].SetActive(false);
            _playerWeapon.weaponInvenory[0].SetActive(true);
            BasicActive();
            IWeapon.activeBasic = true;
        }
    }

    private void BasicActive()
    {
        foreach (GameObject basicActive in weaponBasicActiveIcon)
        {
            basicActive.SetActive(true);
        }

        foreach (GameObject auxiliary in weaponAuxiliaryActiveIcon)
        {
            auxiliary.SetActive(false);
        }
    }

    private void AuxiliaryActive()
    {
        foreach (GameObject basicActive in weaponBasicActiveIcon)
        {
            basicActive.SetActive(false);
        }

        foreach (GameObject auxiliary in weaponAuxiliaryActiveIcon)
        {
            auxiliary.SetActive(true);
        }
    }
}
