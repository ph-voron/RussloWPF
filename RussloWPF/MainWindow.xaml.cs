using RussloWPF.Models.MVVM;
using RussloWPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RussloWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        //
        private Stack<Page> BackStack = new Stack<Page>();
        //
        private void UpdateTitle()
        {
            if (MainContainer.Content == null || MainContainer.Content.GetType() == typeof(Page)) return;
            var page = (Page)MainContainer.Content;
            CurrentPageTitleText.Text = page.Title;
        }
        //
        private void HideNavigationDrawer()
        {
            if(DrawerMenuLayout.Margin.Left >= 0)
            {
                AnimateNavigationDrawer();
            }
        }
        /// <summary>
        /// Проигрывает анимацию смены визуальных состояний боковой панели навигации
        /// </summary>
        private void AnimateNavigationDrawer()
        {
            var buttonAnimation = new ThicknessAnimation();
            bool isExpanded = DrawerMenuLayout.Margin.Left >= 0;
            double startMargin = isExpanded ? 0 : -350;
            double endMargin = isExpanded ? -350 : 0;
            //
            ContentOverlayShading.Visibility = !isExpanded ? Visibility.Visible : Visibility.Collapsed;
            //
            buttonAnimation.From = new Thickness(startMargin, 0, 0, 0);
            buttonAnimation.To = new Thickness(endMargin, 0, 0, 0);
            buttonAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300));
            //аналог интерполяторов анимации android
            buttonAnimation.EasingFunction = new ExponentialEase();
            //
            buttonAnimation.Completed += (sndr, evnt) =>
            {

            };
            DrawerMenuLayout.BeginAnimation(StackPanel.MarginProperty, buttonAnimation);
        }
        //
        public void NavigateToPage(PageTypesEnum page)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                Page targetPage = null;
                switch (page)
                {
                    case PageTypesEnum.loginPage:
                        targetPage = new LoginPage();
                        break;
                    case PageTypesEnum.briefcasePage:
                        targetPage = new BriefcasePage();
                        break;
                    case PageTypesEnum.readerPage:
                        targetPage = new ReaderCEFPage();
                        break;
                }
                if (targetPage != null)
                {
                    HideNavigationDrawer();
                    if (BackStack.Count > 0)
                    {
                        var current = BackStack.Peek();
                        if (current.GetType() == targetPage.GetType()) return;
                    }
                    BackStack.Push(targetPage);
                    MainContainer.Content = targetPage;
                    CurrentPageTitleText.Text = targetPage.Title;
                }
            }));
        }
        //
        public void NavigateBack()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                if (BackStack.Count <= 1) return;
                BackStack.Pop();
                var targetPage = BackStack.Peek();
                if(targetPage != null)
                {
                    MainContainer.Content = targetPage;
                    CurrentPageTitleText.Text = targetPage.Title;
                }
            }));
        }
        //
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }

        public void ShowProgressDialog(bool value)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => 
            {
                ContentOverlayShading.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                LoadingNotification.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NavigateToPage(PageTypesEnum.loginPage);
        }

        private void DrawerMenuButton_Click(object sender, RoutedEventArgs e)
        {
            AnimateNavigationDrawer();
        }

        private void NavigateBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateBack();
        }
    }
}
