﻿using MoneyTrack.WPF.Client.ViewModels;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MoneyTrack.WPF.Client.Views
{
    public class BaseUserControl:UserControl
    {
        public BaseUserControl()
        {
            Loaded += BaseUserControl_Loaded;
        }

        private void BaseUserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is BaseViewModel context)
                Task.Run(async () => await context?.Initialize());
        }
    }
}
