﻿namespace WpfTest.Contracts.Services;

public interface IPersistAndRestoreService
{
    void RestoreData();

    void PersistData();
}