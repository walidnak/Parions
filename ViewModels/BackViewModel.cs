using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parions.ViewModels
{
    class BackViewModel : Conductor<object>.Collection.OneActive
    {
        public BackViewModel()
        {
            ActivateItemAsync(new MenuPrincipalViewModel());
        }

        public void MenuPrincipalCommande()
        {
            if (Items.Count > 1)
            {
                ActivateItemAsync(new MenuPrincipalViewModel());
                var Menu_Principal = Items[0];
                Items.Clear();
                ActivateItemAsync(Menu_Principal);
            }
        }
    }
}
