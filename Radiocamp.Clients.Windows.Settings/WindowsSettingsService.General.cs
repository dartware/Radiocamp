﻿using System;
using System.Reflection;
using Microsoft.Win32;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class WindowsSettingsService
	{

		private Boolean startMinimized;
		protected Boolean showFavoritesAtStart;
		protected Boolean showOnlyCustomAtStart;
		protected SearchEngine searchEngine;

		public String ApplicationName => "Radiocamp";

		[NoStorage]
		[UserSetting]
		[Default(false)]
		public Boolean RunAtWindowsStart
		{
			get => GetAutostart();
			set => SetAutostart(value);
		}

		[UserSetting]
		[Default(false)]
		[Field(nameof(startMinimized))]
		public Boolean StartMinimized
		{
			get => startMinimized;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(false)]
		[Field(nameof(showFavoritesAtStart))]
		public Boolean ShowFavoritesAtStart
		{
			get => showFavoritesAtStart;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(false)]
		[Field(nameof(ShowOnlyCustomAtStart))]
		public Boolean ShowOnlyCustomAtStart
		{
			get => showOnlyCustomAtStart;
			set => SetValue(value);
		}

		[UserSetting]
		[Default(SearchEngine.Google)]
		[Field(nameof(searchEngine))]
		public SearchEngine SearchEngine
		{
			get => searchEngine;
			set => SetValue(value);
		}

		private Boolean GetAutostart()
		{

			RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			Object value = registryKey.GetValue(ApplicationName);

			if (value == null)
			{
				return false;
			}

			if (((String) value) != Assembly.GetExecutingAssembly().Location)
			{
				return false;
			}

			return true;

		}

		private void SetAutostart(Boolean launchOnWindowsStart)
		{

			if (launchOnWindowsStart == GetAutostart())
			{
				return;
			}

			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

			if (launchOnWindowsStart)
			{
				registryKey.SetValue(ApplicationName, Assembly.GetExecutingAssembly().Location);
			}
			else
			{
				registryKey.DeleteValue(ApplicationName);
			}

		}

	}
}