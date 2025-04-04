using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace translate_mock_app.Models
{
    /// <summary>
    /// Represents a captured screen area with extracted text
    /// </summary>
    public class ScreenCapture : INotifyPropertyChanged
    {
        private string _capturedText = string.Empty;
        private DateTime _captureTimestamp;
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private string _detectedLanguage = string.Empty;

        /// <summary>
        /// Text extracted from the screen capture
        /// </summary>
        public string CapturedText
        {
            get => _capturedText;
            set => SetProperty(ref _capturedText, value);
        }

        /// <summary>
        /// When the screen was captured
        /// </summary>
        public DateTime CaptureTimestamp
        {
            get => _captureTimestamp;
            set => SetProperty(ref _captureTimestamp, value);
        }

        /// <summary>
        /// X coordinate of the screen area
        /// </summary>
        public int X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }

        /// <summary>
        /// Y coordinate of the screen area
        /// </summary>
        public int Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }

        /// <summary>
        /// Width of the screen area
        /// </summary>
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        /// <summary>
        /// Height of the screen area
        /// </summary>
        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        /// <summary>
        /// Detected language of the captured text (ISO 639-1 code)
        /// </summary>
        public string DetectedLanguage
        {
            get => _detectedLanguage;
            set => SetProperty(ref _detectedLanguage, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// Represents a translation from one language to another
    /// </summary>
    public class Translation : INotifyPropertyChanged
    {
        private string _originalText = string.Empty;
        private string _translatedText = string.Empty;
        private string _sourceLanguage = string.Empty;
        private string _targetLanguage = string.Empty;
        private DateTime _translationTimestamp;
        private string _translationService = string.Empty;

        /// <summary>
        /// Original text before translation
        /// </summary>
        public string OriginalText
        {
            get => _originalText;
            set => SetProperty(ref _originalText, value);
        }

        /// <summary>
        /// Text after translation
        /// </summary>
        public string TranslatedText
        {
            get => _translatedText;
            set => SetProperty(ref _translatedText, value);
        }

        /// <summary>
        /// Source language code (ISO 639-1)
        /// </summary>
        public string SourceLanguage
        {
            get => _sourceLanguage;
            set => SetProperty(ref _sourceLanguage, value);
        }

        /// <summary>
        /// Target language code (ISO 639-1)
        /// </summary>
        public string TargetLanguage
        {
            get => _targetLanguage;
            set => SetProperty(ref _targetLanguage, value);
        }

        /// <summary>
        /// When the translation was performed
        /// </summary>
        public DateTime TranslationTimestamp
        {
            get => _translationTimestamp;
            set => SetProperty(ref _translationTimestamp, value);
        }

        /// <summary>
        /// Service used for translation (e.g., "DeepL")
        /// </summary>
        public string TranslationService
        {
            get => _translationService;
            set => SetProperty(ref _translationService, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// User preferences for the translation app
    /// </summary>
    public class UserPreferences : INotifyPropertyChanged
    {
        private string _defaultTargetLanguage = "en";
        private string _preferredTranslationService = "DeepL";
        private float _overlayOpacity = 0.8f;

        /// <summary>
        /// Default target language for translations (ISO 639-1 code)
        /// </summary>
        public string DefaultTargetLanguage
        {
            get => _defaultTargetLanguage;
            set => SetProperty(ref _defaultTargetLanguage, value);
        }

        /// <summary>
        /// Preferred translation service
        /// </summary>
        public string PreferredTranslationService
        {
            get => _preferredTranslationService;
            set => SetProperty(ref _preferredTranslationService, value);
        }

        /// <summary>
        /// Opacity of the overlay (0.0 to 1.0)
        /// </summary>
        public float OverlayOpacity
        {
            get => _overlayOpacity;
            set => SetProperty(ref _overlayOpacity, Math.Clamp(value, 0.0f, 1.0f));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// Represents an entry in the translation history
    /// </summary>
    public class TranslationHistoryEntry : INotifyPropertyChanged
    {
        private ScreenCapture _screenCapture;
        private Translation _translation;

        public TranslationHistoryEntry()
        {
            _screenCapture = new ScreenCapture();
            _translation = new Translation();
        }

        /// <summary>
        /// Screen capture associated with this translation
        /// </summary>
        public ScreenCapture ScreenCapture
        {
            get => _screenCapture;
            set => SetProperty(ref _screenCapture, value);
        }

        /// <summary>
        /// Translation details
        /// </summary>
        public Translation Translation
        {
            get => _translation;
            set => SetProperty(ref _translation, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// Collection of translation history entries
    /// </summary>
    public class TranslationHistory : INotifyPropertyChanged
    {
        private ObservableCollection<TranslationHistoryEntry> _entries;

        /// <summary>
        /// List of translation history entries
        /// </summary>
        public ObservableCollection<TranslationHistoryEntry> Entries
        {
            get => _entries;
            set => SetProperty(ref _entries, value);
        }

        public TranslationHistory()
        {
            _entries = new ObservableCollection<TranslationHistoryEntry>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    /// <summary>
    /// Request object for translation service
    /// </summary>
    public class TranslationRequest
    {
        /// <summary>
        /// Text to be translated
        /// </summary>
        public string SourceText { get; set; } = string.Empty;

        /// <summary>
        /// Source language code (ISO 639-1)
        /// </summary>
        public string SourceLanguage { get; set; } = string.Empty;

        /// <summary>
        /// Target language code (ISO 639-1)
        /// </summary>
        public string TargetLanguage { get; set; } = string.Empty;
    }

    /// <summary>
    /// Result object from translation service
    /// </summary>
    public class TranslationResult
    {
        /// <summary>
        /// Original text before translation
        /// </summary>
        public string OriginalText { get; set; } = string.Empty;

        /// <summary>
        /// Text after translation
        /// </summary>
        public string TranslatedText { get; set; } = string.Empty;

        /// <summary>
        /// Source language code (ISO 639-1)
        /// </summary>
        public string SourceLanguage { get; set; } = string.Empty;

        /// <summary>
        /// Target language code (ISO 639-1)
        /// </summary>
        public string TargetLanguage { get; set; } = string.Empty;

        /// <summary>
        /// When the translation was performed
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Service used for translation (e.g., "DeepL")
        /// </summary>
        public string TranslationService { get; set; } = string.Empty;
    }
}