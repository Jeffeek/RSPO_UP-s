﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPO_UP_6.ViewModel
{
    public class CannabisViewModel : ViewModelBase
    {
        private int _currentRow, _currentColumn, _size;
        private EntitySettingsViewModel _settings;

        public int Size
        {
            get => _size;
            set => SetValue(ref _size, value);
        }

        public int Row
        {
            get => _currentRow;
            set => SetValue(ref _currentRow, value);
        }

        public int Column
        {
            get => _currentColumn;
            set => SetValue(ref _currentColumn, value);
        }

        public EntitySettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        public CannabisViewModel()
        {
            Settings = new EntitySettingsViewModel();
        }
    }
}
