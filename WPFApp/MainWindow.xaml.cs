using System;
using System.ComponentModel;
using System.Windows;
using DAL;
using DAL.UnitOfWork;
using EfRepository;
using WPFApp.ViewModels;

namespace WPFApp
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			
			UnitOfWork unitOfWork = new UnitOfWork(new ShopContext());
			DataContext = new AppViewModel(unitOfWork);
		}
	}
}