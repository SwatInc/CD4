using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using CD4.UI.UiSpecificModels;

namespace CD4.UI.UserControls
{
    public partial class GraphsUserControl : XtraUserControl
    {
        #region Private Fields
        private List<TestHistoryModel> _testHistories;
        private ResultType _resultType;

        #endregion

        #region Default Constructor
        public GraphsUserControl()
        {
            InitializeComponent();

            //subscribe for events
            checkEditEnableGraphLabels.CheckedChanged += CheckEditEnableGraphLabels_CheckedChanged;
            toggleSwitchResultsAndResultsWithDates.Toggled += ToggleSwitchResultsAndResultsWithDates_Toggled;
            rangeTrackBarControl.EditValueChanged += RangeTrackBarControl_EditValueChanged;
            this.VisibleChanged += ClearExistingPlotsOnHiding;
        }

        /// <summary>
        /// Clears all existing plots when the user control is hidden.
        /// </summary>
        private void ClearExistingPlotsOnHiding(object sender, EventArgs e)
        {
            if (!Visible)
            {
                ClearAllCurrentPlots();
            }
        }

        #endregion

        #region Event Handlers
        private void RangeTrackBarControl_EditValueChanged(object sender, EventArgs e)
        {
            dynamic editValue = rangeTrackBarControl.EditValue;
            if (!editValue.IsEmpty)
            {
                XYDiagram diagram = (XYDiagram)testHistoryChartControl.Diagram;
                diagram?.AxisX.VisualRange.SetMinMaxValues(editValue.Minimum, editValue.Maximum);
            }
        }

        private void ToggleSwitchResultsAndResultsWithDates_Toggled(object sender, EventArgs e)
        {
            var toggle = (ToggleSwitch)sender;
            if (toggle.IsOn)
            {
                FormatGraphLabels(GraphLabelFormatting.ResultsWithResultDate);
            }
            else
            {
                FormatGraphLabels(GraphLabelFormatting.Results);

            }
        }


        #endregion

        #region Private Methods
        private int GetPointsForSlider()
        {
            return _testHistories.Count;
        }

        /// <summary>
        /// Clears all existing series plots in chartControl
        /// </summary>
        public void ClearAllCurrentPlots()
        {
            this.testHistoryChartControl.Series.Clear();
        }

        private void PlotData(string unit)
        {
            //prepare data
            var seriesName = GetSeriesName();
            //select view type
            var viewType = GetSeriesViewType();
            if (viewType.GetType() != typeof(ViewType))
            {
                XtraMessageBox.Show((string)viewType);
                return;
            };

            //prep the series
            Series series = new Series(seriesName, viewType)
            {
                DataSource = _testHistories,
                ArgumentDataMember = nameof(TestHistoryModel.Number), //X-axis values member name
            };

            //set Y-axis values member name
            series.ValueDataMembers.AddRange(new string[] { nameof(TestHistoryModel.Result) });
            //set value scale type for Y-axis as Qualitative if values are codified, if numeric set scale type as numeric
            if (viewType == ViewType.Line)
            {
                series.ValueScaleType = ScaleType.Numerical;
                //make marker visible and make it a cross
                ((LineSeriesView)series.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                ((LineSeriesView)series.View).LineMarkerOptions.Kind = MarkerKind.Cross;
            }
            else
            {
                series.ValueScaleType = ScaleType.Qualitative;
            }

            //X-axis value acle type is always qualitative
            series.ArgumentScaleType = ScaleType.Qualitative;

            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True; //use this as a setting to toggle lables on graphs
            series.Label.ResolveOverlappingMode = ResolveOverlappingMode.HideOverlapped;
            //set Crosshair Label pattern for displaying when mouse hovers on a pointer to display result date and result
            series.CrosshairLabelPattern = "{ResultDate}\r\n{Result} " + unit;
            //set label pattern
            series.Label.TextPattern = "{ResultDate}\r\n{Result}";
            //add the series to the chart
            testHistoryChartControl.Series.Add(series);

            //enable scrolling on X-axis
            XYDiagram diagram = (XYDiagram)testHistoryChartControl.Diagram;
            diagram.AxisX.VisualRange.SetMinMaxValues("1", "10");
            diagram.EnableAxisXScrolling = true;
            diagram.ScrollingOptions.UseKeyboard = true;

        }

        private dynamic GetSeriesViewType()
        {
            switch (_resultType)
            {
                case ResultType.Numeric:
                    return ViewType.Line;
                case ResultType.Textual:
                    return "Cannot plot historical graphs for textual data.";
                case ResultType.Codified:
                    return ViewType.Point;
                default:
                    return "The data type must be Numeric or Codified to plot a chart!";
            }
        }

        private string GetSeriesName()
        {
            return _testHistories.FirstOrDefault().TestName;
        }

        private void FormatGraphLabels(GraphLabelFormatting labelFormat)
        {
            switch (labelFormat)
            {
                case GraphLabelFormatting.Results:
                    //set label pattern
                    testHistoryChartControl.Series[0].Label.TextPattern = "{Result}";
                    break;
                case GraphLabelFormatting.ResultsWithResultDate:
                    testHistoryChartControl.Series[0].Label.TextPattern = "{ResultDate}\r\n{Result}";
                    break;
                default:
                    break;
            }
        }

        private void CheckEditEnableGraphLabels_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckEdit)sender;
            if (checkbox.Checked)
            {
                toggleSwitchResultsAndResultsWithDates.EditValue = null;
                toggleSwitchResultsAndResultsWithDates.Enabled = true;
                ShowGraphLabels();
            }
            else
            {
                toggleSwitchResultsAndResultsWithDates.IsOn = false;
                toggleSwitchResultsAndResultsWithDates.Enabled = true;
                HideGraphLabels();
            }
        }

        private void HideGraphLabels()
        {
            testHistoryChartControl.Series[0].LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

        }

        private void ShowGraphLabels()
        {
            testHistoryChartControl.Series[0].LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
        }

        #endregion

        #region Public Methods
        public void InitializeChart(List<TestHistoryModel> testHistories, ResultType resultType, string unit)
        {
            _testHistories = testHistories;
            _resultType = resultType;
            var maxNumberOfPoints = GetPointsForSlider();
            for (int i = 0; i < maxNumberOfPoints; i++)
            {
                rangeTrackBarControl.Properties.Labels.Add(new DevExpress.XtraEditors.Repository.TrackBarLabel() { Label = i.ToString(), Value = i});
            }
            rangeTrackBarControl.Properties.Maximum = maxNumberOfPoints;
            rangeTrackBarControl.RefreshLabels();
            rangeTrackBarControl.Properties.ShowLabels = true;
            PlotData(unit);
            SetGraphDisplayRange();
        }

        public void SetGraphDisplayRange()
        {
            var maxNumberOfPoints = GetPointsForSlider();
            rangeTrackBarControl.Value = new DevExpress.XtraEditors.Repository.TrackBarRange() { Maximum = maxNumberOfPoints, Minimum = maxNumberOfPoints - 10 };
        }

        #endregion

        #region Enums
        public enum ResultType
        {
            Numeric,
            Textual,
            Codified
        }
        private enum GraphLabelFormatting
        {
            Results,
            ResultsWithResultDate
        }

        #endregion

    }
}
