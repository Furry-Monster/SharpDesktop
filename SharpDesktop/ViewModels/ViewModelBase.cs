using ReactiveUI;

namespace SharpDesktop.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public ViewModelBase()
        {

        }
        public ViewModelBase(IScreen hostScreen)
        {
        }
    }
}
