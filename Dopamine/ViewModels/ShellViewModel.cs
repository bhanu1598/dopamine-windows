using Dopamine.Services.Dialog;
using Dopamine.Services.File;
using Dopamine.Services.JumpList;
using Dopamine.Services.Playback;
using Dopamine.Services.Taskbar;
using Dopamine.Services.Update;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Dopamine.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private bool isOverlayVisible;

        public bool IsOverlayVisible
        {
            get { return this.isOverlayVisible; }
            set { SetProperty<bool>(ref this.isOverlayVisible, value); }
        }

        public ITaskbarService TaskbarService { get; }

        public DelegateCommand PlayPreviousCommand { get; set; }
        public DelegateCommand PlayNextCommand { get; set; }
        public DelegateCommand PlayOrPauseCommand { get; set; }
        public DelegateCommand LoadedCommand { get; set; }

        public ShellViewModel(IPlaybackService playbackService, ITaskbarService taskbarService, IDialogService dialogService,
            IJumpListService jumpListService, IFileService fileService, IUpdateService updateService)
        {
            this.TaskbarService = taskbarService;

            dialogService.DialogVisibleChanged += isDialogVisible => { this.IsOverlayVisible = isDialogVisible; };

            this.PlayPreviousCommand = new DelegateCommand(async () => await playbackService.PlayPreviousAsync());
            this.PlayNextCommand = new DelegateCommand(async () => await playbackService.PlayNextAsync());
            this.PlayOrPauseCommand = new DelegateCommand(async () => await playbackService.PlayOrPauseAsync());

            this.LoadedCommand = new DelegateCommand(() => fileService.ProcessArguments(Environment.GetCommandLineArgs()));

            // Populate the JumpList
            jumpListService.PopulateJumpListAsync();
        }
    }
}