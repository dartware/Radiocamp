﻿using System;
using Dartware.Radiocamp.Clients.Shared.Models;

namespace Dartware.Radiocamp.Clients.Windows.Core.Models
{
	public sealed class WindowsSettings : Settings
	{
		public Double MainWindowWidth { get; set; }
		public Double MainWindowHeight { get; set; }
		public Double MainWindowLeft { get; set; }
		public Double MainWindowTop { get; set; }
		public Boolean HotkeysIsEnabled { get; set; }
		public Boolean StartMinimized { get; set; }
	}
}