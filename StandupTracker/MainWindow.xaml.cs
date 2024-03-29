﻿using AutoMapper;
using Standuptracker.AuthenticationTokens.Dtos;
using StandupTracker.Applications;
using StandupTracker.Applications.Dtos;
using StandupTracker.Applications.Services.Authentication;
using StandupTracker.Applications.Validations;
using StandupTracker.Authentication;
using StandupTracker.Exeptions;
using StandupTracker.Menu;
using StandupTracker.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StandupTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AuthenticationStore.SetAuthenticated(false);

            MenuManager.WindowLayout = windowLayout;
            MenuManager.MenuControl = menuControl;
            MenuManager.MenuControl.ItemsSource = MenuManager.menuItems;

            MenuManager.AddStackPanelsToWindow();
        }
        
        private void menuControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (menuControl.SelectedItem is not Menu.MenuItem menuItem)
            {
                throw new StackPanelNotFoundExeption();
            }

            MenuManager.ChangeView(menuItem);
        }
    }
}
