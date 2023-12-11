using Dopamine.ViewModels;
using Dopamine.Services.Playback;
using CommonServiceLocator;

namespace Dopamine.ViewModels.Common
{
    public class HorizontalVolumeControlsViewModel : VolumeControlsViewModel
    {
        public HorizontalVolumeControlsViewModel() : base(ServiceLocator.Current.GetInstance<IPlaybackService>())
        {
        }
    }
}