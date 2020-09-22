﻿using System.Diagnostics.CodeAnalysis;
using Dartware.Radiocamp.Clients.Shared.Services;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Database;

namespace Dartware.Radiocamp.Clients.Windows.Settings
{
	[SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
	[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
	public sealed partial class WindowsSettingsService : SettingsService<WindowsSettings, DatabaseContext>, ISettings
	{
		public WindowsSettingsService(DatabaseContext databaseContext) : base(databaseContext)
		{
		}
	}
}