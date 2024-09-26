using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace translate_mock_app
{
    public partial class MainPage : ContentPage
    {
        private string? _translationResult;
        public string? TranslationResult
        {
            get => _translationResult;
            set
            {
                if (_translationResult != value)
                {
                    _translationResult = value;
                    OnPropertyChanged(nameof(TranslationResult));
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            TranslationResult = "No translation yet."; // Initialize with a default value
        }

        private void InitializeComponent()
        {

        }

        private async void OnTranslateClicked(object sender, EventArgs e)
        {
            TranslationResult = "Translation in progress...";

            // Simulate translation process
            await Task.Delay(2000);

            TranslationResult = "Translated text will appear here";
        }
    }
}