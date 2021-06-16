﻿using MoneyTrack.WPF.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var context = (BaseViewModel)DataContext;
            context.Initialize();
        }
    }
}