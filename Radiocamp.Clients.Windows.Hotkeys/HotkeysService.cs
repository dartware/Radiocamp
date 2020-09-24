﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.EntityFrameworkCore;
using DynamicData;
using NHotkey;
using NHotkey.Wpf;
using Dartware.Radiocamp.Clients.Windows.Core.Models;
using Dartware.Radiocamp.Clients.Windows.Database;
using Dartware.Radiocamp.Clients.Windows.Settings;

using Hotkey = Dartware.Radiocamp.Clients.Windows.Core.Models.Hotkey;

namespace Dartware.Radiocamp.Clients.Windows.Hotkeys
{
	public sealed class HotkeysService : IHotkeys
	{

		private readonly DatabaseContext databaseContext;
		private readonly ISettings settings;
		private readonly IDictionary<HotkeyCommand, Boolean> registered;

		public ISourceCache<Hotkey, HotkeyCommand> All { get; private set; }

		public event Action PlayPauseHotkeyPressed;
		public event Action StartStopRecordHotkeyPressed;
		public event Action MuteUnmuteHotkeyPressed;
		public event Action VolumeUpHotkeyPressed;
		public event Action VolumeDownHotkeyPressed;
		public event Action ShowHideSwitchHotkeyPressed;

		public HotkeysService(DatabaseContext databaseContext, ISettings settings)
		{
			this.databaseContext = databaseContext;
			this.settings = settings;
			registered = new ConcurrentDictionary<HotkeyCommand, Boolean>();
			All = new SourceCache<Hotkey, HotkeyCommand>(hotkey => hotkey.Command);
		}

		public void Initialize()
		{

			All.AddOrUpdate(databaseContext.Hotkeys.AsNoTracking().ToList());

			foreach (Hotkey hotkey in All.Items)
			{
				registered[hotkey.Command] = false;
			}

			if (settings.HotkeysIsEnabled)
			{
				RegisterAll();
			}

			settings.HotkeysIsEnabledChanged += OnHotkeysIsEnabledChanged;

		}

		public async Task UpdateAsync(Hotkey hotkey)
		{

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			Unregister(hotkey.Command);
			Register(hotkey);
			All.AddOrUpdate(hotkey);
			databaseContext.Hotkeys.Attach(hotkey);
			await databaseContext.SaveChangesAsync();

			databaseContext.Entry(hotkey).State = EntityState.Detached;

		}

		public void Enable(HotkeyCommand command)
		{
			Enable(Get(command));
		}

		public void Disable(HotkeyCommand command)
		{
			Disable(Get(command));
		}

		public void RegisterAll()
		{

			if (!settings.HotkeysIsEnabled)
			{
				return;
			}

			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				foreach (Hotkey hotkey in All.Items)
				{
					Register(hotkey);
				}
			}));

		}

		public void UnregisterAll()
		{
			Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
			{
				foreach (Hotkey hotkey in All.Items)
				{
					Unregister(hotkey.Command);
				}
			}));
		}

		private void Enable(Hotkey hotkey)
		{

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			hotkey.IsEnabled = true;

			Register(hotkey);
			All.AddOrUpdate(hotkey);
			databaseContext.Hotkeys.Attach(hotkey);
			databaseContext.SaveChanges();

		}

		private void Disable(Hotkey hotkey)
		{

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			hotkey.IsEnabled = false;

			Unregister(hotkey.Command);
			All.AddOrUpdate(hotkey);
			databaseContext.Hotkeys.Attach(hotkey);
			databaseContext.SaveChanges();

		}

		private Hotkey Get(HotkeyCommand command) => All.Items.FirstOrDefault(hotkey => hotkey.Command == command);

		private void Register(Hotkey hotkey)
		{

			if (!settings.HotkeysIsEnabled)
			{
				return;
			}

			if (hotkey == null)
			{
				throw new ArgumentNullException(nameof(hotkey), "Hotkey cannot be null.");
			}

			if (!hotkey.IsEnabled)
			{
				return;
			}

			if (hotkey.Key == null || hotkey.ModifierKey == null)
			{
				return;
			}

			EventHandler<HotkeyEventArgs> handler = null;

			switch (hotkey.Command)
			{
				case HotkeyCommand.PlayPause: handler = (sender, args) => PlayPauseHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.StartStopRecord: handler = (sender, args) => StartStopRecordHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.MuteUnmute: handler = (sender, args) => MuteUnmuteHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.VolumeUp: handler = (sender, args) => VolumeUpHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.VolumeDown: handler = (sender, args) => VolumeDownHotkeyPressed?.Invoke(); break;
				case HotkeyCommand.ShowHideSwitch: handler = (sender, args) => ShowHideSwitchHotkeyPressed?.Invoke(); break;
			}

			registered.TryGetValue(hotkey.Command, out Boolean isRegistered);

			if (handler != null && !isRegistered)
			{
				
				HotkeyManager.Current.AddOrReplace(Enum.GetName(typeof(HotkeyCommand), hotkey.Command), hotkey.Key.Value, hotkey.ModifierKey.Value, handler);
				
				registered[hotkey.Command] = true;

			}

		}

		private void Unregister(HotkeyCommand command)
		{
			
			registered.TryGetValue(command, out Boolean isRegistered);

			if (isRegistered)
			{

				HotkeyManager.Current.Remove(Enum.GetName(typeof(HotkeyCommand), command));

				registered[command] = false;

			}

		}

		private void OnHotkeysIsEnabledChanged(Boolean hotkeysIsEnabled)
		{
			if (hotkeysIsEnabled)
			{
				RegisterAll();
			}
			else
			{
				UnregisterAll();
			}
		}

	}
}