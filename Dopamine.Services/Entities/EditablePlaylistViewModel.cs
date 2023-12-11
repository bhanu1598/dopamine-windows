using Digimezzo.Foundation.Core.Utils;
using Dopamine.Core.IO;
using Dopamine.Services.Playlist;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;

namespace Dopamine.Services.Entities
{
    public class EditablePlaylistViewModel : BindableBase
    {
        private string playlistName;
        private PlaylistType type;
        private bool matchAnyRule;
        private SmartPlaylistLimitViewModel limit;
        private ObservableCollection<SmartPlaylistTypeViewModel> limitTypes = new ObservableCollection<SmartPlaylistTypeViewModel>();
        private SmartPlaylistTypeViewModel selectedLimitType;
        private ObservableCollection<SmartPlaylistRuleViewModel> rules = new ObservableCollection<SmartPlaylistRuleViewModel>();
        private string path;

        public EditablePlaylistViewModel(string playlistName, PlaylistType type)
        {
            this.playlistName = playlistName;
            this.type = type;
            this.rules.Add(new SmartPlaylistRuleViewModel());
            this.limit = new SmartPlaylistLimitViewModel(SmartPlaylistLimitType.Songs, 25);

            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.Songs, ResourceUtils.GetString("Language_Smart_Playlist_Songs")));
            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.GigaBytes, ResourceUtils.GetString("Language_Gigabytes_Short")));
            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.MegaBytes, ResourceUtils.GetString("Language_Megabytes_Short")));
            this.limitTypes.Add(new SmartPlaylistTypeViewModel(SmartPlaylistLimitType.Minutes, ResourceUtils.GetString("Language_Smart_Playlist_Minutes")));
            this.selectedLimitType = this.limitTypes.First();
        }

        public string Path
        {
            get { return this.path; }
            set { SetProperty<string>(ref this.path, value); }
        }

        public string PlaylistName
        {
            get { return this.playlistName; }
            set { SetProperty<string>(ref this.playlistName, value); }
        }

        public PlaylistType Type
        {
            get { return this.type; }
            set { SetProperty<PlaylistType>(ref this.type, value); }
        }

        public bool MatchAnyRule
        {
            get { return this.matchAnyRule; }
            set { SetProperty<bool>(ref this.matchAnyRule, value); }
        }

        public SmartPlaylistLimitViewModel Limit
        {
            get { return this.limit; }
            set { SetProperty<SmartPlaylistLimitViewModel>(ref this.limit, value); }
        }

        public ObservableCollection<SmartPlaylistTypeViewModel> LimitTypes
        {
            get { return this.limitTypes; }
            set { SetProperty<ObservableCollection<SmartPlaylistTypeViewModel>>(ref this.limitTypes, value); }
        }

        public ObservableCollection<SmartPlaylistRuleViewModel> Rules
        {
            get { return this.rules; }
            set { SetProperty<ObservableCollection<SmartPlaylistRuleViewModel>>(ref this.rules, value); }
        }

        public SmartPlaylistTypeViewModel SelectedLimitType
        {
            get { return this.selectedLimitType; }
            set {
                SetProperty<SmartPlaylistTypeViewModel>(ref this.selectedLimitType, value);
                
                if(this.limit != null)
                {
                    this.limit.Type = value.Type;
                }
            }
        }

        public void AddRule()
        {
            this.rules.Add(new SmartPlaylistRuleViewModel());
        }

        public void RemoveRule(SmartPlaylistRuleViewModel rule)
        {
            // There must be at least 1 rule
            if (this.rules.Count > 1)
            {
                this.rules.Remove(rule);
            }
        }
    }
}
