using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using DevExpress.BarCodes;
using DevExpress.Docs.Text;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Functions;
using DevExpress.Utils;
using DevExpress.XtraSpreadsheet;
namespace CustomItem
{
    public partial class CustomDrawModule : SpreadSheetTutorialControlBase {
        #region Fields
        const string IncorectData = "Incorrect parameter values";
        static System.Drawing.Font tipFont = new System.Drawing.Font("Arial", 11);
        SpreadsheetControl spreadsheetControl1;
        IWorkbook book;
        CustomDrawDocumentGenerator generator;
        DefinedNameCollection definedNames;
        List<IAreaFormulaValidator> areaFormulaValidators = new List<IAreaFormulaValidator>();
        #endregion

        #region Properties
        public SpreadsheetControl SpreadsheetControl1
        {
            get { return spreadsheetControl1; }
        }
        #endregion

        public CustomDrawModule() {
            InitializeComponent();
            spreadsheetControl1.BeginUpdate();
            book = spreadsheetControl1.Document;
            generator = new CustomDrawDocumentGenerator(book);
            book = generator.Generate(DemoUtils.GetRelativePath("CalculatorOfArea_template.xlsx"));
            definedNames = book.DefinedNames;
            FillAreaFormulaValidators();
            spreadsheetControl1.CustomDrawCell += DrawFormulaTip;
            spreadsheetControl1.CustomDrawCellBackground +=spreadsheetControl1_CustomDrawCellBackground;
            spreadsheetControl1.EndUpdate();
            spreadsheetControl1.Document.History.Clear();
        }
        void FillAreaFormulaValidators() {
            areaFormulaValidators.Add(new Triangle1AreaFormulaValidator(definedNames));
            areaFormulaValidators.Add(new Triangle2AreaFormulaValidator(definedNames));
            areaFormulaValidators.Add(new Triangle3AreaFormulaValidator(definedNames));
        }
        protected override void DoShow() {
            base.DoShow();
            spreadsheetControl1.Focus();
        }
        void spreadsheetControl1_CustomDrawCellBackground(object sender, CustomDrawCellBackgroundEventArgs e) {
            if(String.IsNullOrEmpty(e.Cell.Formula))
                return;

            
        }
        void DrawCellFill(CustomDrawCellBackgroundEventArgs e, bool isError) {
            e.BackColor = isError ? DXColor.FromArgb(0xFF, 0xA5, 0xA5) : DXColor.Empty;
        }
        void DrawFormulaTip(object sender, CustomDrawCellEventArgs e) {
            if(String.IsNullOrEmpty(e.Cell.Formula))
                return;

        }
        void DrawErrorTooltip(CustomDrawCellEventArgs e, bool isError) {
            e.Handled = true;
            e.DrawDefault();

            const int alpha = 255;
            Color foreColor = GetSemitransparentColor(SystemColors.InfoText, alpha);
            Color backColor = GetSemitransparentColor(SystemColors.Info, alpha);
            System.Drawing.Font font = tipFont;
            Rectangle bounds = e.Bounds;
            string text = isError ? IncorectData : e.Cell.Formula;
            SizeF size = e.Graphics.MeasureString(text, font, Int32.MaxValue, StringFormat.GenericDefault);
            Size tooltipSize = new Size((int)Math.Round(size.Width), (int)Math.Round(size.Height));
            Rectangle textBounds = new Rectangle(bounds.X + 1, bounds.Y - tooltipSize.Height - 2, tooltipSize.Width+3, tooltipSize.Height);
            Rectangle markerBounds = textBounds;
            markerBounds.Inflate(2, 1);
            Point[] points = new Point[] { new Point(markerBounds.Left, markerBounds.Top), new Point(markerBounds.Right, markerBounds.Top), new Point(markerBounds.Right, markerBounds.Bottom), new Point(markerBounds.Left + Math.Min(e.FillBounds.Height / 4, markerBounds.Height / 2), markerBounds.Bottom), new Point(markerBounds.Left, markerBounds.Bottom + e.FillBounds.Height / 2), new Point(markerBounds.Left, markerBounds.Top) };
            e.Graphics.FillPolygon(e.Cache.GetSolidBrush(backColor), points);
            e.Graphics.DrawPolygon(e.Cache.GetPen(foreColor), points);
            e.Graphics.DrawString(text, font, e.Cache.GetSolidBrush(foreColor), textBounds, StringFormat.GenericDefault);
        }
        Color GetSemitransparentColor(Color color, int alpha) {
            return Color.FromArgb(alpha, color.R, color.G, color.B);
        }

        void checkEdit_CheckedChanged(object sender, EventArgs e) {
            spreadsheetControl1.Refresh();
        }

        private void spreadsheetCommandBarButtonItem90_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
    public interface IAreaFormulaValidator {
        bool IsAreaFormulaCell(Cell cell);
        bool IsValidParams();
        string AreaFormulaDefinedName { get; }
    }
    public abstract class AreaFormulaValidatorBase : IAreaFormulaValidator {
        readonly DefinedNameCollection definedNames;
        protected const int MaxAnglesInQuadrangle = 180;

        protected AreaFormulaValidatorBase(DefinedNameCollection definedNames) {
            this.definedNames = definedNames;
        }

        public abstract string AreaFormulaDefinedName { get; }
        public abstract bool IsValidParams();

        public bool IsAreaFormulaCell(Cell cell) {
            if (!definedNames.Contains(AreaFormulaDefinedName))
                return false;
            Range definedNameRange = definedNames.GetDefinedName(AreaFormulaDefinedName).Range;
            return cell.Worksheet.Name == definedNameRange.Worksheet.Name &&
                   cell.TopRowIndex == definedNameRange.TopRowIndex &&
                   cell.LeftColumnIndex == definedNameRange.LeftColumnIndex &&
                   cell.BottomRowIndex == definedNameRange.BottomRowIndex &&
                   cell.RightColumnIndex == definedNameRange.RightColumnIndex;
        }
        protected bool IsNumericAndGreaterThenZero(CellValue value) {
            return value.IsNumeric && value.NumericValue > 0;
        }
        protected CellValue DefinedNameNamericCellValue(string df) {
            return definedNames.GetDefinedName(df).Range.Value;
        }
    }
    public class Triangle1AreaFormulaValidator : AreaFormulaValidatorBase {
        const string DF_Triangle1_A = "Triangle1_A";
        const string DF_Triangle1_B = "Triangle1_B";
        const string DF_Triangle1_Alpha = "Triangle1_Alpha";
        const string DF_Triangle1_Area = "Triangle1_Area";
        protected const int AnglesSumInTriangle = 180;

        public Triangle1AreaFormulaValidator(DefinedNameCollection definedNames)
            : base(definedNames) {
        }

        public override string AreaFormulaDefinedName { get { return DF_Triangle1_Area; } }
        public override bool IsValidParams() {
            CellValue a = DefinedNameNamericCellValue(DF_Triangle1_A);
            CellValue b = DefinedNameNamericCellValue(DF_Triangle1_B);
            CellValue alpha = DefinedNameNamericCellValue(DF_Triangle1_Alpha);

            return IsNumericAndGreaterThenZero(a) && IsNumericAndGreaterThenZero(b) && IsNumericAndGreaterThenZero(alpha) &&
                   alpha.NumericValue < AnglesSumInTriangle;
        }
    }
    public class Triangle2AreaFormulaValidator : AreaFormulaValidatorBase {
        const string DF_Triangle2_A = "Triangle2_A";
        const string DF_Triangle2_H = "Triangle2_H";
        const string DF_Triangle2_Area = "Triangle2_Area";

        public Triangle2AreaFormulaValidator(DefinedNameCollection definedNames)
            : base(definedNames) {
        }

        public override string AreaFormulaDefinedName { get { return DF_Triangle2_Area; } }
        public override bool IsValidParams() {
            CellValue a = DefinedNameNamericCellValue(DF_Triangle2_A);
            CellValue h = DefinedNameNamericCellValue(DF_Triangle2_H);

            return IsNumericAndGreaterThenZero(a) && IsNumericAndGreaterThenZero(h);
        }
    }
    public class Triangle3AreaFormulaValidator : AreaFormulaValidatorBase {
        const string DF_Triangle3_A = "Triangle3_A";
        const string DF_Triangle3_B = "Triangle3_B";
        const string DF_Triangle3_C = "Triangle3_С";
        const string DF_Triangle3_Area = "Triangle3_Area";

        public Triangle3AreaFormulaValidator(DefinedNameCollection definedNames)
            : base(definedNames) {
        }

        public override string AreaFormulaDefinedName { get { return DF_Triangle3_Area; } }
        public override bool IsValidParams() {
            CellValue a = DefinedNameNamericCellValue(DF_Triangle3_A);
            CellValue b = DefinedNameNamericCellValue(DF_Triangle3_B);
            CellValue c = DefinedNameNamericCellValue(DF_Triangle3_C);

            return IsNumericAndGreaterThenZero(a) && IsNumericAndGreaterThenZero(b) && IsNumericAndGreaterThenZero(c)
                   && a.NumericValue + b.NumericValue > c.NumericValue
                   && a.NumericValue + c.NumericValue>b.NumericValue
                   && b.NumericValue + c.NumericValue >a.NumericValue;
        }

        
    }   
}
