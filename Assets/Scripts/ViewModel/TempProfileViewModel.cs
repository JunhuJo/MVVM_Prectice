using System.ComponentModel;
using UnityEngine;

public class TempProfileViewModel
{
    private string _name;
    private int _userId;

    public int UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    public string Name
    { 
        get { return _name; }
        set
        {
            if(_name == value)
                return;

            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    #region ProChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    { 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}