using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
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
        private string _commentaire = string.Empty;
        private string _nom = string.Empty;
        private string _prenom = string.Empty;

        public MainWindowViewModel()
        {
            this.Nom = "Entrez le nom";

            this.EditPopupCommand = new DelegateCommand(this.EditPopupCommandExecute);
            this.MessageBoxCommand = new DelegateCommand(this.MessageBoxCommandExecute);
            this.ConfirmationCommand = new DelegateCommand(this.ConfirmationCommandExecute);

            // evenements sur lesquels la vue écoute
            this.NotificationRequest = new InteractionRequest<INotification>();
            this.ConfirmationRequest = new InteractionRequest<IConfirmation>();
            this.EditRequest = new InteractionRequest<IEditPopupNotification>();
        }

        #region event interactionsRequest

        public InteractionRequest<IConfirmation> ConfirmationRequest { get; private set; }
        public InteractionRequest<IEditPopupNotification> EditRequest { get; private set; }
        public InteractionRequest<INotification> NotificationRequest { get; private set; }

        #endregion event interactionsRequest

        #region Commandes

        public ICommand ConfirmationCommand { get; private set; }
        public ICommand EditPopupCommand { get; private set; }
        public ICommand MessageBoxCommand { get; private set; }

        #endregion Commandes

        #region Public Properties

        public string Commentaire
        {
            get
            {
                return this._commentaire;
            }
            set
            {
                this.SetProperty(ref _commentaire, value);
            }
        }

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

        public string Prenom
        {
            get
            {
                return this._prenom;
            }
            set
            {
                this.SetProperty(ref _prenom, value);
            }
        }

        #endregion Public Properties

        #region Private Methods

        private void ConfirmationCommandExecute()
        {
            this.ConfirmationRequest.Raise(
                new Confirmation()
                {
                    Title = "Alerte utilisateur",
                    Content = "Voulez vous formater votre disque ?",
                },
                confirmation =>
                {
                    if (confirmation.Confirmed)
                    {
                        System.Diagnostics.Debug.Print(@"Format C:\");
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print(@"Format quand même");
                    }
                });
        }

        private void EditPopupCommandExecute()
        {
            this.EditRequest.Raise(
                new EditPopupNotification()
                {
                    Title = "Formulaire d'edition",
                    Commentaire = this.Commentaire,
                    Nom = this.Nom,
                    Prenom = this.Prenom
                },
                confirmation =>
                {
                    if (confirmation.Confirmed)
                    {
                        this.Commentaire = confirmation.Commentaire;
                        this.Nom = confirmation.Nom;
                        this.Prenom = confirmation.Prenom;
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print(@"Edition abandonée");
                    }
                });
        }

        private void MessageBoxCommandExecute()
        {
            this.NotificationRequest.Raise(
                new Notification()
                {
                    Title = "Alerte utilisateur",
                    Content = "La commande a bien été executée."
                },
                notification =>
                {
                    System.Diagnostics.Debug.Print("La notification a été fermée");
                });
        }

        #endregion Private Methods
    }
}