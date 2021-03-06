﻿using System;
using System.Windows;
using System.Windows.Interop;

namespace Dartware.Radiocamp.Clients.Windows.UI.Windows
{
	public abstract class BaseWindow : Window
	{

		private const Int32 SC_KEYMENU = 0xf100;
		private const Int32 WM_SYSCOMMAND = 0x112;

		public static readonly DependencyProperty OverlayVisibleProperty = DependencyProperty.Register(nameof(OverlayVisible), typeof(Boolean), typeof(BaseWindow), new PropertyMetadata(default(Boolean)));

		public Boolean OverlayVisible
		{
			get => (Boolean) GetValue(OverlayVisibleProperty);
			set => SetValue(OverlayVisibleProperty, value);
		}

		public BaseWindow()
		{
		}

		protected override void OnSourceInitialized(EventArgs args)
		{

			base.OnSourceInitialized(args);

			if (HwndSource.FromVisual(this) is HwndSource source)
			{
				source.AddHook(new HwndSourceHook(WinProc));
			}

		}

		private IntPtr WinProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
		{

			switch (msg)
			{
				case WM_SYSCOMMAND:
				{

					Int32 sc = (LOWORD(wParam.ToInt32()) & 0xFFF0);

					handled = sc == SC_KEYMENU;

					break;

				}
			}

			return new IntPtr(1);

		}

		private Int32 LOWORD(Int32 value) => (value & 0xffff);

	}
}