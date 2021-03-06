﻿#region Using namespaces

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_3.Models.EntityFramework.Models;
using RSPO_UP_3.Services;
using RSPO_UP_3.ViewModel.Base;

#endregion

namespace RSPO_UP_3.ViewModel
{
	internal class RegistrationViewModel : ViewModelBase
	{
		public RegistrationViewModel(List<User> users)
		{
			_users = users;
			RegisterNewUser = new RelayCommand(OnRegisterButtonExecuted, CanRegisterButtonExecute);
		}

		#region commands

		public ICommand RegisterNewUser { get; }

		#endregion

		#region fields

		private string _name = string.Empty;
		private string _password = string.Empty;
		private string _repeatPassword = string.Empty;
		private string _login = string.Empty;
		private readonly List<User> _users;

		#endregion

		#region command methods

		private bool CanRegisterButtonExecute() => NameText.Length >= 3 &&
		                                           LoginText.Length >= 5 &&
		                                           PasswordText.Length >= 7 &&
		                                           PasswordText == RepeatPasswordText;

		private void OnRegisterButtonExecuted()
		{
			var user = new User
			           {
				           Login = LoginText,
				           Name = NameText,
				           Password = PasswordText
			           };

			var checkUser = _users.SingleOrDefault(x => x.Login == user.Login);
			if (checkUser == null)
			{
				UsersProvider.AddNewUser(user);
				_users.Add(user);
				MessageBox.Show($"User with login {LoginText} was registered!",
				                "Successful registration",
				                MessageBoxButton.OK,
				                MessageBoxImage.Information);

				LoginText = string.Empty;
				PasswordText = string.Empty;
				RepeatPasswordText = string.Empty;
				NameText = string.Empty;
			}
			else
			{
				MessageBox.Show($"User with login {LoginText} is already exists!",
				                "Bad login",
				                MessageBoxButton.OK,
				                MessageBoxImage.Error);
			}
		}

		#endregion

		#region props

		public string NameText
		{
			get => _name;
			set => SetValue(ref _name, value);
		}

		public string PasswordText
		{
			get => _password;
			set => SetValue(ref _password, value);
		}

		public string RepeatPasswordText
		{
			get => _repeatPassword;
			set => SetValue(ref _repeatPassword, value);
		}

		public string LoginText
		{
			get => _login;
			set => SetValue(ref _login, value);
		}

		#endregion
	}
}