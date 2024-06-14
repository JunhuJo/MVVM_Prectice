using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions;
using tempViewModelName.Extensions;

public class TempProflieUI : MonoBehaviour
{
    [SerializeField] Text Text_Name;

    private TempProfileViewModel _vm;

    private void OnEnable()
    {
        if (_vm == null)
        {
            _vm = new TempProfileViewModel();
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
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                Text_Name.text = $"¿Ã∏ß : {_vm.Name}";
                 break;
        }
    }
}

