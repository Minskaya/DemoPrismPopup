using Prism.Interactivity.InteractionRequest;

namespace DemoPrismPopup
{
    public interface IEditPopupNotification : IConfirmation
    {
        string Commentaire { get; set; }

        string Nom { get; set; }

        string Prenom { get; set; }
    }
}