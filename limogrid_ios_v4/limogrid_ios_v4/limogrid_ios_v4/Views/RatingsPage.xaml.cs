﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace limo_droid_v4.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RatingsPage : ContentPage
	{
		public RatingsPage ()
		{
			InitializeComponent ();
            Browser.Source = "http://limogrid.com/api/limogrid/Views/Reatings/Main/pg_MainRatings.cfm";
        }
    }
}