using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Util;

namespace DateTimeForm
{
	public class TimePickerFragment : DialogFragment, 
	TimePickerDialog.IOnTimeSetListener

	{
		// TAG can be any string of your choice.
		public static readonly string TAG = "X:" + typeof (TimePickerFragment).Name.ToUpper();

		// Initialize this value to prevent NullReferenceExceptions.
		Action<DateTime> _dateSelectedHandler = delegate { };

		public static TimePickerFragment NewInstance(Action<DateTime> onDateSelected)
		{
			TimePickerFragment frag = new TimePickerFragment();
			frag._dateSelectedHandler = onDateSelected;
			return frag;
		}

		public override Dialog OnCreateDialog(Bundle savedInstanceState)
		{


			DateTime currently = DateTime.Now;
			TimePickerDialog dialog = new TimePickerDialog(Activity, 
				this, 
				currently.Hour,
				currently.Minute,
				false
			);
			return dialog;
		}

		//public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		public void OnTimeSet(TimePicker view, int hour, int minute)
		{
			// Note: monthOfYear is a value between 0 and 11, not 1 and 12!
			DateTime selectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
			Log.Debug(TAG, selectedDate.ToLongDateString());
			_dateSelectedHandler(selectedDate);
		}
	}
}

