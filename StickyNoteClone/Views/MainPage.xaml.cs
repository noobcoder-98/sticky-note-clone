using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using StickyNoteClone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StickyNoteClone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainViewModel _viewModel;
        public MainPage()
        {
            this.InitializeComponent();
            _viewModel = App.ServiceProvider.GetRequiredService<MainViewModel>();
        }

        private async void AddNote_Click(object sender, RoutedEventArgs e)
        {
            var newView = CoreApplication.CreateNewView();
            int newViewId = 0;

            await newView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(typeof(NotePage));
                Window.Current.Content = frame;
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
                newView.TitleBar.ExtendViewIntoTitleBar = true;
                var appView = ApplicationView.GetForCurrentView();

                var titleBar = appView.TitleBar;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonHoverBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }

        private async void ui_lvNotes_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (sender is not ListView listView || listView.SelectedItem == null)
            {
                return;
            }


            var newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            var selectedItem = listView.SelectedItem;
            await newView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(typeof(NotePage), selectedItem);
                Window.Current.Content = frame;
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
                newView.TitleBar.ExtendViewIntoTitleBar = true;
                var appView = ApplicationView.GetForCurrentView();

                var titleBar = appView.TitleBar;
                titleBar.ButtonBackgroundColor = Colors.Transparent;
                titleBar.ButtonHoverBackgroundColor = Colors.Transparent;
                titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);

            listView.SelectedIndex = -1;
            listView.SelectedItem = null;
            listView.UpdateLayout();
        }

        private void ui_lvNotes_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
