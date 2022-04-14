using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace lab9vs_pr.Views
{
    public partial class MainWindow : Window
    {
        private Carousel _carousel;
        private Button _back, _forward;

        public MainWindow()
        {
            InitializeComponent();
            _back.Click += (s, e) => _carousel.Previous();
            _forward.Click += (s, e) => _carousel.Next();
            _carousel.PageTransition = new CrossFade(TimeSpan.FromSeconds(0.35));

        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            _carousel = this.FindControl<Carousel>("carousel");
            _back = this.FindControl<Button>("back");
            _forward = this.FindControl<Button>("forward");

        }
    }
}