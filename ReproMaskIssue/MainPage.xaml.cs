using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Legacy;

namespace ReproMaskIssue
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }

    public class MainPageViewModel : ReactiveObject
    {
        public ReactiveList<DateCellViewModel> Dates { get; }
        public ReactiveCommand<Unit, Unit> AddDateCommand { get; }

        public MainPageViewModel()
        {
            Dates = new ReactiveList<DateCellViewModel>();
            AddDateCommand = ReactiveCommand.Create(() => Dates.Add(new DateCellViewModel(DateTime.Today, cellViewModel => Dates.Remove(cellViewModel))));
        }
    }

    public class DateCellViewModel
    {
        public string Date { get; set; }
        public ReactiveCommand<Unit, Unit> RemoveCommand { get; }
        public DateCellViewModel(DateTimeOffset date, Action<DateCellViewModel> removeThis)
        {
            Date = date.ToString("dd/MM/yyyy");
            RemoveCommand = ReactiveCommand.Create(() => removeThis(this));
        }

    }
}
