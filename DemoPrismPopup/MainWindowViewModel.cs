using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoPrismPopup
{
    public class MainWindowViewModel : BindableBase
    {
        private string _nom;

        public MainWindowViewModel(IInteractionService)
        {
            this.Nom = "Entrez le nom";
            this.PopupWithServiceCommand = new DelegateCommand(this.PopupWithServiceCommandExecute);
            this.MessageBoxCommand = new DelegateCommand(this.MessageBoxCommandExecute);
        }

        public ICommand MessageBoxCommand { get; set; }

        public string Nom
        {
            get
            {
                return this._nom;
            }
            set
            {
                this.SetProperty(ref _nom, value);
            }
        }

        public ICommand Popup2 { get; private set; }

        public ICommand PopupWithServiceCommand { get; private set; }

        private void MessageBoxCommandExecute()
        {
            throw new NotImplementedException();
        }

        private void PopupWithServiceCommandExecute()
        {
            throw new NotImplementedException();
        }
    }
}