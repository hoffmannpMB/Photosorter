﻿using System.Windows.Input;
using FotoSortierer_v2.Helper.Adapter.Interfaces;
using Model.Interfaces;

namespace FotoSortierer_v2.ViewModel.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Viewmodel for flipview.
    /// </summary>
    public interface IFlipViewViewModel : IFlipViewModel
    {
        /// <summary>
        /// List of all imported images.
        /// </summary>
        IObservableCollectionAdapter<IPhotoViewModel> Images { get; set; }
    }
}