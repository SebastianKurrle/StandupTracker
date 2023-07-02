using AutoMapper;
using StandupTracker.Applications;
using StandupTracker.Applications.Dtos;
using StandupTracker.Applications.Services.Authentication;
using StandupTracker.Applications.Validations;
using StandupTracker.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            IMapper mapper = new MapperConfiguration(cfg =>
            cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();

            UserLoginValidator validator = new UserLoginValidator();

            AuthenticationLoginService authenticationLoginService = 
                new AuthenticationLoginService(mapper, validator);

            authenticationLoginService.LoginUser(new UserLogin("Test", "testing321"));
        }
    }
}
