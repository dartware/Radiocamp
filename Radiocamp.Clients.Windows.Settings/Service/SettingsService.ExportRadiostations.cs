﻿using System;
using Microsoft.EntityFrameworkCore;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	public sealed partial class SettingsService<DatabaseContextType> where DatabaseContextType : DbContext
	{

#pragma warning disable 0649

		private Boolean exportRadiostationsAll;
		private Boolean exportRadiostationsOnlyFavoritesOrCustom;
		private Boolean exportRadiostationsFavoritesOnly;
		private Boolean exportRadiostationsCustomOnly;
		private Boolean exportRadiostationsSaveSoundSettings;
		private Boolean exportRadiostationsSaveFavoritesTags;
		private ExportFormat exportRadiostationsFormat;
		private String exportRadiostationsPath;

#pragma warning restore 0649

		public String ExportRadiostationsFileFormat => ExportRadiostationsFormat switch
		{
			ExportFormat.Binary => "radcampback",
			ExportFormat.JSON => "json",
			_ => "radcampback"
		};

		[Default(true)]
		[Field(nameof(exportRadiostationsAll))]
		public Boolean ExportRadiostationsAll
		{
			get => exportRadiostationsAll;
			set => SetValue(value);
		}

		[Default(false)]
		[Field(nameof(exportRadiostationsOnlyFavoritesOrCustom))]
		public Boolean ExportRadiostationsOnlyFavoritesOrCustom
		{
			get => exportRadiostationsOnlyFavoritesOrCustom;
			set => SetValue(value);
		}

		[Default(false)]
		[Field(nameof(exportRadiostationsFavoritesOnly))]
		public Boolean ExportRadiostationsFavoritesOnly
		{
			get => exportRadiostationsFavoritesOnly;
			set => SetValue(value);
		}

		[Default(false)]
		[Field(nameof(exportRadiostationsCustomOnly))]
		public Boolean ExportRadiostationsCustomOnly
		{
			get => exportRadiostationsCustomOnly;
			set => SetValue(value);
		}

		[Default(true)]
		[Field(nameof(exportRadiostationsSaveSoundSettings))]
		public Boolean ExportRadiostationsSaveSoundSettings
		{
			get => exportRadiostationsSaveSoundSettings;
			set => SetValue(value);
		}

		[Default(true)]
		[Field(nameof(exportRadiostationsSaveFavoritesTags))]
		public Boolean ExportRadiostationsSaveFavoritesTags
		{
			get => exportRadiostationsSaveFavoritesTags;
			set => SetValue(value);
		}

		[Default(ExportFormat.Binary)]
		[Field(nameof(exportRadiostationsFormat))]
		public ExportFormat ExportRadiostationsFormat
		{
			get => exportRadiostationsFormat;
			set => SetValue(value);
		}

		[Default("")]
		[Field(nameof(exportRadiostationsPath))]
		public String ExportRadiostationsPath
		{
			get => exportRadiostationsPath;
			set => SetValue(value);
		}

	}
}