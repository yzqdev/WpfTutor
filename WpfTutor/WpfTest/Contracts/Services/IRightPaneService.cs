﻿using System.Windows.Controls;

using MahApps.Metro.Controls;

namespace WpfTest.Contracts.Services;

public interface IRightPaneService
{
    event EventHandler PaneOpened;

    event EventHandler PaneClosed;

    void OpenInRightPane(string pageKey, object parameter = null);

    void Initialize(Frame rightPaneFrame, SplitView splitView);

    void CleanUp();
}
