using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MaterialDateTime.Controls;
using MaterialDateTime.Droid.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ExtendedDatePicker), typeof(ExtendedDatePickerRenderer))]
namespace MaterialDateTime.Droid.Controls
{
    class ExtendedDatePickerRenderer : Xamarin.Forms.Material.Android.MaterialDatePickerRenderer
    {
        private readonly Context _context;
        private DatePickerDialog _dialog;

        public ExtendedDatePickerRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override DatePickerDialog CreateDatePickerDialog(int year, int month, int day)
        {
            _dialog = new DatePickerDialog(_context, (o, e) =>
            {
                Element.Date = e.Date;
                ((IElementController)Element).SetValueFromRenderer(Xamarin.Forms.VisualElement.IsFocusedPropertyKey, false);
                Control.ClearFocus();

                _dialog = null;
            }, year, month, day);

            return _dialog;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ExtendedDatePicker.DateProperty.PropertyName || e.PropertyName == ExtendedDatePicker.FormatProperty.PropertyName)
            {
                SetDate(Element.Date);
            }
        }

        void SetDate(DateTime date)
        {
            Control.EditText.Text = date.ToString(Element.Format);
        }
    }
}