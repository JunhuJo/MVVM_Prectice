using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions;


public class TopLeftUI : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;
    [SerializeField] Image Image_Icon;

    //뷰모델을 들고 있게 됩니다.
    private TopLeftVViewModel _vm;
    
    private void OnEnable()
    {
        if (_vm == null)
        {
            _vm = new TopLeftVViewModel();
            _vm.PropertyChanged += OnProertyChanged;
            _vm.RegisterEnvetOnEnable();
            _vm.RefeshViewModel();
        }
    }

    private void OnDisable()
    {
        if (_vm != null)
        { 
            _vm.UnRegisterEnvetOnDisable();
            _vm.PropertyChanged -= OnProertyChanged;
            _vm = null;
        }
    }


    private void OnProertyChanged(object sneder, PropertyChangedEventArgs e)
    { 
        switch(e.PropertyName) 
        {
            case nameof(_vm.Name):
                Text_Name.text = _vm.Name;
                break;
            case nameof(_vm.Level):
                Text_Level.text = $"Lv.{_vm.Level}";
                break;
            case nameof(_vm.IconName):
                break;
        }
    }

    
}
