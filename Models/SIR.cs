using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace COVID_SIR.Models
{
    class SIR
    {
        private int Susceptible;
        private int Infected;
        private int Removed;
        private double TransmissionRate;
        private double RemoveRate;

        public int susceptible
        {
            get => Susceptible;
            set => SetProperty(ref Susceptible, value);
        }

        public int infected
        {
            get => Infected;
            set => SetProperty(ref Infected, value);
        }

        public int removed
        {
            get => Removed;
            set => SetProperty(ref Removed, value);
        }

        public double tr          //Transmission Rate
        {
            get => TransmissionRate;
            set => SetProperty(ref TransmissionRate, value);
        }

        public double rr          //Remove Rate
        {
            get => RemoveRate;
            set => SetProperty(ref RemoveRate, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName="", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
