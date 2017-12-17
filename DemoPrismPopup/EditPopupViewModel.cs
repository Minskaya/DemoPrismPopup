using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrismPopup
{
    public class EditPopupViewModel : BindableBase, IInteractionRequestAware
    {
        private IEditPopupNotification _notification;

        public EditPopupViewModel()
        {
            this.CancelCommand = new DelegateCommand(this.CancelCommandExecute);
            this.ApplyCommand = new DelegateCommand(this.ApplyCommandExecute);
        }

        public DelegateCommand ApplyCommand { get; private set; }

        public DelegateCommand CancelCommand { get; }

        public Action FinishInteraction { get; set; }

        public INotification Notification
        {
            get { return _notification; }
            set { SetProperty(ref _notification, (IEditPopupNotification)value); }
        }

        private void ApplyCommandExecute()
        {
            _notification.Confirmed = true;
            this.FinishInteraction?.Invoke();
        }

        private void CancelCommandExecute()
        {
            _notification.Confirmed = false;
            this.FinishInteraction?.Invoke();
        }
    }
}