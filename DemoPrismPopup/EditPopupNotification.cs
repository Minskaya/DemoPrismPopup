using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPrismPopup
{
    public class EditPopupNotification : Confirmation, IEditPopupNotification
    {
        public string Commentaire { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }
    }
}