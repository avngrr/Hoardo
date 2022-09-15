using System.Windows.Controls;

namespace Client.WpfApp.UI.Movies;
/// <summary>
/// Interaction logic for Movies.xaml
/// </summary>
public partial class Movies : UserControl
{
    private MoviesViewModel viewModel;
    public Movies()
    {
        InitializeComponent();
        viewModel = (MoviesViewModel)DataContext;
    }

}
