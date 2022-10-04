using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darts.Logic.UI.BaseViewModels
{
    public class ViewModelAuswertung<T> : ViewModelValidate
    {
        private T selectedItem;

        public ViewModelAuswertung()
        {
            ItemList = new List<T>();
            Labels = new[] { "" };
            XAxes = new List<Axis>
                {
                    new Axis()
                    {
                        LabelsPaint = new SolidColorPaint{ Color = SKColors.CornflowerBlue },
                        Position = AxisPosition.Start,
                        Labels = Labels,
                        UnitWidth = 0.7
                    }
                };
            YAxes = new List<Axis>
                {
                    new Axis()
                    {
                        LabelsPaint = new SolidColorPaint{ Color = SKColors.CornflowerBlue },
                        Position = AxisPosition.Start,
                        Labeler = (value) =>  string.Format("{0:N2}€", value)

                    }
                };
        }

        public ISeries[] Series { get; set; }
        public List<Axis> XAxes { get; set; }
        public List<Axis> YAxes { get; set; }
        public T Data { get; set; }
        public IList<T> ItemList { get; set; }

        public string[] Labels { get; set; }

        public virtual T SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged();
            }
        }
    }
}