﻿using System.Threading.Tasks;

namespace DayHelper
{
    public interface IUIManager
    {
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}