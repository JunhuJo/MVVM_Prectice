using System.ComponentModel;


public class TopLeftVViewModel
{
    private int _uverId;
    private string _name;
    private int _level;
    private string _iconName;

    public int UserId
    { 
        get { return _uverId; }
        set 
        { 
            _uverId = value; 
        }
    }

    public string Name
    {
        get { return _name; }
        set 
        {
            if (_name == value)
                return;

            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public int Level
    {
        get { return _level; }
        set
        {
            if(_level == value)
                return;
            
            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }

    public string IconName
    {
        get {return _iconName; }
        set
        {
            if(_iconName == value)
                return;

            _iconName = value;
            OnPropertyChanged(nameof(IconName));
        }
    }

    //데이터 바인딩을 하려면 이게 필요
    #region ProChanged
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    { 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

}
