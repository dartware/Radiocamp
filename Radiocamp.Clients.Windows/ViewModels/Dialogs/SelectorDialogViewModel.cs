﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Threading;
using DynamicData;
using DynamicData.Binding;
using Dartware.Radiocamp.Clients.Shared;
using Dartware.Radiocamp.Clients.Shared.Extensions;
using Dartware.Radiocamp.Clients.Windows.Dialogs;

namespace Dartware.Radiocamp.Clients.Windows.ViewModels
{
	public sealed class SelectorDialogViewModel<SelectorType> : DynamicDialogViewModel where SelectorType : struct, IConvertible
	{

		private readonly SelectorDialogArgs<SelectorType> args;

		private Action<SelectorType> changeCallback;
		private ISourceCache<SelectorDialogValue<SelectorType>, SelectorType> list;
		private SelectorType current;
		private String titleLocalizationResourceKey;
		private String searchQuery;
		private Boolean search;
		private ReadOnlyObservableCollection<SelectorDialogValue<SelectorType>> values;

		public ReadOnlyObservableCollection<SelectorDialogValue<SelectorType>> Values => values;

		public String TitleLocalizationResourceKey
		{
			get => titleLocalizationResourceKey;
			private set => SetAndRaise(ref titleLocalizationResourceKey, value);
		}

		public String SearchQuery
		{
			get => searchQuery;
			set => SetAndRaise(ref searchQuery, value);
		}

		public Boolean Search
		{
			get => search;
			set => SetAndRaise(ref search, value);
		}

		public SelectorDialogViewModel(SelectorDialogArgs<SelectorType> args) : base(args)
		{
			this.args = args;
		}

		public override void Initialize()
		{

			base.Initialize();

			list = new SourceCache<SelectorDialogValue<SelectorType>, SelectorType>(value => value.Value);

			Width = 300;
			MaxHeight = 420;
			Search = true;

			if (args != null)
			{
				
				current = args.Current;
				changeCallback = args.Callback;
				Search = args.Search;

				if (args.Width > 0)
				{
					Width = args.Width;
				}

				if (args.Height > 0)
				{

					if (args.Height > MaxHeight)
					{
						args.Height = MaxHeight;
					}

					Height = args.Height;

				}

			}

			Type type = typeof(SelectorType);

			if (Attribute.IsDefined(type, typeof(LocalizationAttribute)))
			{
				if (Attribute.GetCustomAttribute(type, typeof(LocalizationAttribute)) is LocalizationAttribute localizationAttribute)
				{
					TitleLocalizationResourceKey = localizationAttribute.Key;
				}
			}
			else
			{
				TitleLocalizationResourceKey = type.Name;
			}

			IEnumerable<SelectorType> values = Enum.GetValues(type) as IEnumerable<SelectorType>;

			list.AddOrUpdate((values ?? Array.Empty<SelectorType>()).Select(value =>
			{

				String localizationResourceKey = value.ToLocalizationResourceKey();
				String searchText = Application.Current.Resources[localizationResourceKey] as String;

				return new SelectorDialogValue<SelectorType>()
				{
					Value = value,
					IsCurrent = value.Equals(current),
					LocalizationResourceKey = localizationResourceKey,
					SearchText = searchText,
					HintLocalizationResourceKey = value.ToHintLocalizationResourceKey(),
					SelectCallback = OnSelectedChanged
				};

			}));

			IObservable<Func<SelectorDialogValue<SelectorType>, Boolean>> searchFilter = this.WhenValueChanged(viewModel => viewModel.SearchQuery)
																							 .Select(BuildSearcher);

			IDisposable listSubscription = list.Connect()
											   .NotEmpty()
											   .Filter(searchFilter)
											   .Sort(SortExpressionComparer<SelectorDialogValue<SelectorType>>.Ascending(value => value.SearchText))
											   .ObserveOnDispatcher(DispatcherPriority.Background)
											   .Bind(out this.values)
											   .DisposeMany()
											   .Subscribe();

			disposables.Add(listSubscription);

		}

		protected override void OnEscape()
		{
			base.OnEscape();
			Close();
		}

		protected override void OnEnter()
		{
			base.OnEnter();
			Close();
		}

		private void OnSelectedChanged(SelectorDialogValue<SelectorType> newSelected)
		{

			if (newSelected == null)
			{
				return;
			}

			if (newSelected.Value.Equals(current))
			{
				return;
			}

			current = newSelected.Value;

			SelectorDialogValue<SelectorType> oldSelected = list.Items.FirstOrDefault(value => value.IsCurrent);

			if (oldSelected != null)
			{

				oldSelected.IsCurrent = false;

				list.AddOrUpdate(oldSelected);

			}

			newSelected.IsCurrent = true;

			list.AddOrUpdate(newSelected);
			changeCallback?.Invoke(current);

		}

		private Func<SelectorDialogValue<SelectorType>, Boolean> BuildSearcher(String searchQuery)
		{

			if (String.IsNullOrEmpty(searchQuery))
			{
				return _ => true;
			}

			return selectorValue =>
			{

				String preparedSearchQuery = SearchQuery.ToLower().Trim();
				String preparedSearchText = selectorValue.SearchText.ToLower();

				return preparedSearchText.Contains(preparedSearchQuery);

			};

		}

	}
}