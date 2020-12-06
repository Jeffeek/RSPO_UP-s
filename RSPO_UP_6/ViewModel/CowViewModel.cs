﻿using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using RSPO_UP_6.Model.Controllers;

namespace RSPO_UP_6.ViewModel
{
    public class CowViewModel : ViewModelBase
    {
        private readonly object _monitor = new object();
        private ObservableCollection<bool> _lives;
        private int _row, _column;
        private EntitySettingsViewModel _settings;
        public int Size { get; set; }

        public event GoCow CowPositionChanged;

        public int Row 
        { 
            get => _row; 
            set => SetValue(ref _row, value);
        }

        public int Column
        {
            get => _column;
            set => SetValue(ref _column, value);
        }

        public ObservableCollection<bool> Lives
        {
            get => _lives;
            set => SetValue(ref _lives, value);
        }

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        public async Task MoveUp()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Row == 0) return;
                Row--;
                CowPositionChanged?.Invoke(MoveDirection.Up);
            }
        }

        public async Task MoveDown()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Row) return;
                Row++;
                CowPositionChanged?.Invoke(MoveDirection.Down);
            }
        }

        public async Task MoveRight()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Size - 1 == Column) return;
                Column++;
                CowPositionChanged?.Invoke(MoveDirection.Right);
            }
        }

        public async Task MoveLeft()
        {
            await Task.Delay(Settings.Delay);
            lock (_monitor)
            {
                if (Column == 0) return;
                Column--;
                CowPositionChanged?.Invoke(MoveDirection.Left);
            }
        }

        public CowViewModel()
        {
            Settings = new EntitySettingsViewModel();
            Settings.ImagePath = $"{Directory.GetCurrentDirectory()}\\Files\\cow.gif";
        }
    }
}
