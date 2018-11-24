using System.Windows;
using System.Windows.Media;
using KMA.APZRPMJ2018.TextEditor.Tools;

namespace KMA.APZRPMJ2018.TextEditor.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Model for document format properties.
    /// </summary>
    public class FormatModel : ObservableObject
    {
        private FontStyle _style;
        public FontStyle Style
        {
            get => _style;
            set => OnPropertyChanged(ref _style, value);
        }

        private FontWeight _weight;
        public FontWeight Weight
        {
            get => _weight;
            set => OnPropertyChanged(ref _weight, value);
        }

        private FontFamily _family;
        public FontFamily Family
        {
            get => _family;
            set => OnPropertyChanged(ref _family, value);
        }

        private TextWrapping _wrap;
        public TextWrapping Wrap
        {
            get => _wrap;
            set
            {
                OnPropertyChanged(ref _wrap, value);
                IsWrapped = value == TextWrapping.Wrap ? true : false;
            }
        }

        private bool _isWrapped;
        public bool IsWrapped
        {
            get => _isWrapped;
            set => OnPropertyChanged(ref _isWrapped, value);
        }

        private double _size;
        public double Size
        {
            get => _size;
            set => OnPropertyChanged(ref _size, value);
        }
    }
}
