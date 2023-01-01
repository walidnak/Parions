using Caliburn.Micro;

namespace Parions.ViewModels
{
    class MenuPrincipalViewModel : Screen
    {

        public MenuPrincipalViewModel()
        {

        }

        public void CreerUnServeurCommande()
        {
            var conductor = this.Parent as IConductor;
            conductor.ActivateItemAsync(new CreerUnServeurViewModel());
        }

        public void RejoindreLequipeCommande()
        {
            var conductor = this.Parent as IConductor;
            conductor.ActivateItemAsync(new RejoindreLequipeViewModel());
        }

    }
}
