﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using RSPO_UP_6.Model;
using RSPO_UP_6.Model.Map;
using RSPO_UP_6.View;
using RSPO_UP_6.View.Maps;

namespace RSPO_UP_6.ViewModel
{
    public class CowAndWeedGameViewModel : ViewModelBase
    {
        private SettingsViewModel _settings;
        private Page _previousPage;
        private Page _currentPage;
        private MapViewModel _map;

        public ICommand OpenSettingsCommand { get; }
        public ICommand OpenMapCommand { get; }

        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }

        public MapViewModel Map
        {
            get => _map;
            set => SetValue(ref _map, value);
        }

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                SetValue(ref _currentPage, value);
                if (_currentPage != null)
                    _currentPage.DataContext = this;
            }
        }

        public SettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        private void OnOpenSettingsExecuted()
        {
            if (CurrentPage is SettingsPage)
            {
                CurrentPage = _previousPage;
                if (Map != null)
                    Map.Bomb.IsGameStopped = false;
            }
            else
            {
                Map.Bomb.IsGameStopped = true;
                _previousPage = CurrentPage;
                CurrentPage = new SettingsPage()
                {
                    DataContext = this
                };
            }
        }

        private void OnLoadMapExecute()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt"
            };
            if (!(dialog.ShowDialog() ?? false)) return;
            var file = new FileWorker(dialog.FileName);
            var text = file.Read();
            var map = TextToMapConverter.Convert(text);
            Map = new MapViewModel(map);
            BuildMap();
            ReloadObjects();
        }

        private void BuildMap()
        {
            switch (Map.CurrentMap.Size)
            {
                case 10:
                    CurrentPage = new Map10x10(Map.Bricks, Map.CurrentMap.Map);
                    break;
                case 8:
                    CurrentPage = new Map8x8(Map.Bricks, Map.CurrentMap.Map);
                    break;
                case 6:
                    CurrentPage = new Map6x6(Map.Bricks, Map.CurrentMap.Map);
                    break;
            }
        }

        private void ReloadObjects()
        {
            var map = Map.CurrentMap;
            Map = new MapViewModel(map);
            Settings = new SettingsViewModel()
            {
                BombSettings = Map.Bomb.Settings,
                WolfSettings = Map.Wolf.Settings,
                CannabisSettings = Map.Cannabis.Settings,
                CowSettings = Map.Cow.Settings
            };
            Map.OnGameResult += OnGameResult;
        }

        private void OnGameResult(object sender, bool isWin)
        {
            MessageBox.Show(isWin ? "CONGRAT" : "FUC");
            ReloadObjects();
        }

        public CowAndWeedGameViewModel()
        {
            MoveDownCommand = new RelayCommand(async () => await Map.Cow.MoveDown());
            MoveUpCommand = new RelayCommand(async () => await Map.Cow.MoveUp());
            MoveRightCommand = new RelayCommand(async () => await Map.Cow.MoveRight());
            MoveLeftCommand = new RelayCommand(async () => await Map.Cow.MoveLeft());
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted);
            OpenMapCommand = new RelayCommand(OnLoadMapExecute);
            Settings = new SettingsViewModel()
            {
                GameRedirectionIndex = 0
            };
        }
    }
}
