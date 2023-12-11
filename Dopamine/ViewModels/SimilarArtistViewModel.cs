using Prism.Mvvm;

namespace Dopamine.ViewModels
{
    public class SimilarArtistViewModel : BindableBase
    {
        private string name;
        private string url;
        private string imageUrl;
   
        public string Name
        {
            get { return this.name; }
            set { SetProperty<string>(ref this.name, value); }
        }

        public string Url
        {
            get { return this.url; }
            set { SetProperty<string>(ref this.url, value); }
        }

        public string ImageUrl
        {
            get { return this.imageUrl; }
            set { SetProperty<string>(ref this.imageUrl, value); }
        }
    }
}