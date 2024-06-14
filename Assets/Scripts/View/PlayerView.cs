using System.ComponentModel;
using UnityEngine;
using ViewModel.Extensions;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] TextMesh TextMesh_Name;
    [SerializeField] Text MainText;
    [SerializeField] Text subText;
    [SerializeField] Text LevelText;
    [SerializeField] Text SubLevelText;
    [SerializeField] TextMesh TextMesh_Level;
    [SerializeField] Animator Animator_Player;
    [SerializeField] GameObject Prefab_SpecialLevelUp;

    private PlayerViewModel _vm;

    private void OnEnable()
    {
        if (_vm == null)
        {
            _vm = new PlayerViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterEventsOnEnable();
            _vm.RefreshViewModel();
        }
    }

    private void OnDisable()
    {
        if (_vm != null)
        {
            _vm.UnRegisterOnDisable();
            _vm.PropertyChanged -= OnPropertyChanged;
            _vm = null;
        }
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                TextMesh_Name.text = $"{_vm.Name}";
                MainText.text = $"이름 : {_vm.Name}";
                subText.text = $"이름 : {_vm.Name}";
                break;
            case nameof(_vm.Level):
                TextMesh_Level.text = $"Lv.{_vm.Level}";
                LevelText.text = $"Lv.{_vm.Level}";
                SubLevelText.text = $"레벨 : {_vm.Level}";
                Animator_Player.SetTrigger("LevelUp");
                CheckSpecialLevelUP(_vm.Level);
                break;
        }
    }

    private void CheckSpecialLevelUP(int level)
    {
        if (level % 10 == 0)
        {
            Instantiate(Prefab_SpecialLevelUp, this.transform);
        }
    }


}
