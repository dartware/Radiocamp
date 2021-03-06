﻿using System;
using Dartware.Radiocamp.Clients.Shared.Models;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Core.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed class Settings
	{

		public Guid Id { get; set; }

		// Main window

		public Double MainWindowWidth { get; set; }
		public Double MainWindowHeight { get; set; }
		public Double MainWindowLeft { get; set; }
		public Double MainWindowTop { get; set; }
		public Double MainWindowCompactAdvancedHeight { get; set; }
		public WindowMode MainWindowMode { get; set; }
		public AdvancedCompactPosition MainWindowAdvancedCompactPosition { get; set; }

		//General

		public Boolean StartMinimized { get; set; }
		public Boolean ShowFavoritesAtStart { get; set; }
		public Boolean ShowOnlyCustomAtStart { get; set; }
		public SearchEngine SearchEngine { get; set; }
		public Boolean ShowOnlyFavorites { get; set; }
		public SortingType SortingType { get; set; }

		// Export radiostations

		public Boolean ExportRadiostationsAll { get; set; }
		public Boolean ExportRadiostationsOnlyFavoritesOrCustom { get; set; }
		public Boolean ExportRadiostationsFavoritesOnly { get; set; }
		public Boolean ExportRadiostationsCustomOnly { get; set; }
		public Boolean ExportRadiostationsSaveSoundSettings { get; set; }
		public Boolean ExportRadiostationsSaveFavoritesTags { get; set; }
		public ExportFormat ExportRadiostationsFormat { get; set; }
		public String ExportRadiostationsPath { get; set; }

		// Tray

		public Boolean AlwaysShowTrayIcon { get; set; }
		public Boolean HideApplicationOnCloseButtonClick { get; set; }
		public Boolean HideApplicationOnMinimizeButtonClick { get; set; }

		// UI

		public Localization Localization { get; set; }
		public Boolean IsNightMode { get; set; }
		public Boolean MainWindowTopmost { get; set; }
		public Boolean MainWindowTopmostOnlyCompact { get; set; }
		public Boolean HideInTaskbar { get; set; }
		public Boolean HideInTaskbarOnlyCompact { get; set; }

		// Sound

		public Double Volume { get; set; }
		public Int32 VolumeStep { get; set; }

		// Hotkeys

		public Boolean HotkeysIsEnabled { get; set; }

		// Filters

		public Country Country { get; set; }
		public Genre Genre { get; set; }
		public Boolean IsCustomOnly { get; set; }

	}
}