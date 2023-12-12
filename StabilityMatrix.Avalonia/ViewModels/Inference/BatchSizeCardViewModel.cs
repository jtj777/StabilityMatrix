﻿using CommunityToolkit.Mvvm.ComponentModel;
using StabilityMatrix.Avalonia.Controls;
using StabilityMatrix.Avalonia.Models.Inference;
using StabilityMatrix.Avalonia.ViewModels.Base;
using StabilityMatrix.Core.Attributes;
using StabilityMatrix.Core.Models.Api.Comfy.Nodes;

namespace StabilityMatrix.Avalonia.ViewModels.Inference;

[View(typeof(BatchSizeCard))]
[ManagedService]
[Transient]
public partial class BatchSizeCardViewModel : LoadableViewModelBase, IComfyStep
{
    [ObservableProperty]
    private int batchSize = 1;

    [ObservableProperty]
    private int batchCount = 1;

    [ObservableProperty]
    private bool isBatchIndexEnabled;

    [ObservableProperty]
    private int batchIndex = 1;

    /// <summary>
    /// Sets batch size to connections.
    /// Provides:
    /// <list type="number">
    /// <item><see cref="ComfyNodeBuilder.NodeBuilderConnections.BatchSize"/></item>
    /// <item><see cref="ComfyNodeBuilder.NodeBuilderConnections.BatchIndex"/></item>
    /// </list>
    /// </summary>
    public void ApplyStep(ModuleApplyStepEventArgs e)
    {
        e.Builder.Connections.BatchSize = BatchSize;
        e.Builder.Connections.BatchIndex = IsBatchIndexEnabled ? BatchIndex : null;
    }
}
