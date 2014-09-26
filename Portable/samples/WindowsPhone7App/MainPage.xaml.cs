using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Flurry.Analytics.Portable;
using PortableClassLibrary;

namespace WindowsPhone7App
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly SharedCode sharedCode;

        public MainPage()
        {
            InitializeComponent();

            sharedCode = ((App)Application.Current).Shared;
            DataContext = sharedCode;
        }
    }
}