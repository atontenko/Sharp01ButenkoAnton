using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Sharp01ButenkoAnton.Annotations;

namespace Sharp01ButenkoAnton
{
    internal class BDViewModel : INotifyPropertyChanged
    {
        private readonly BDModel _bdModel = new BDModel();

        public DateTime InputDate
        {
            get
            {
                return _bdModel.Calculations;
            }
            set
            {
                _bdModel.Calculations = value;

                if (!_bdModel.IsValid)
                {
                    MessageBox.Show("You have entered invalid date!");
                }
                else
                {
                    if (_bdModel.IsBirthday)
                    {
                        MessageBox.Show("Happy birthday! Have a nice day!");
                    }
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(EasternZodiac));
                OnPropertyChanged(nameof(WesternZodiac));
            }
        }

        public string Age
        {
            get
            {
                return _bdModel.Age;
            }
        }

        public string WesternZodiac
        {
            get
            {
                return _bdModel.WesternZodiac;
            }
        }

        public string EasternZodiac
        {
            get
            {
                return _bdModel.EasternZodiac;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
