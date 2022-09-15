using System.Windows.Controls;
using Client.Wpf.ViewModels;

namespace Client.Wpf.Views;
public partial class MoviesView : UserControl
{
    private MoviesViewModel _viewModel => (MoviesViewModel)DataContext;
    public MoviesView()
    {
        InitializeComponent();
    }
    private void btnFirst_Click(object sender, System.EventArgs e)
    {
        _viewModel.LoadData(1, _viewModel.PageSize);
    }

    private void btnNext_Click(object sender, System.EventArgs e)
    {
        _viewModel.LoadData(_viewModel.CurrentPage + 1, _viewModel.PageSize);
    }
    private void btnPrev_Click(object sender, System.EventArgs e)
    {
        _viewModel.LoadData(_viewModel.CurrentPage - 1, _viewModel.PageSize);
    }
    private void btnLast_Click(object sender, System.EventArgs e)
    {

    }

    private async void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Enter)
        {
            await _viewModel.SearchData(((TextBox)sender).Text);
        }
    }
}
