using System;
using Android.App;
using Android.Util;
using Android.OS;
using Android.Widget;

namespace DateTimeForm
{
	public class DatePickerFragment : DialogFragment,
	DatePickerDialog.IOnDateSetListener
	{
		/* uma string que será utilizada com o log. Pode conter qualquer texto. */
		public static readonly string TAG = "X:" + typeof (DatePickerFragment).Name.ToUpper();

		//Inicializa esse valor para prevenir NullReferenceExceptions.
		Action<DateTime> _dateSelectedHandler = delegate { };

		/* Define o método para criar uma nova instância da classe DatePickerFragment.
		 * Atribui a função onDateSelected à ação _dateSelectedHandler.
		*/
		public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
		{
			DatePickerFragment frag = new DatePickerFragment();
			frag._dateSelectedHandler = onDateSelected;
			return frag;
		}

		/* 
		 * Cria uma nova instância de Dialog, invocando um DatePickerDialog
		 * com a data atual.
		 */
		public override Dialog OnCreateDialog(Bundle savedInstanceState)
		{
			DateTime currently = DateTime.Now;
			DatePickerDialog dialog = new DatePickerDialog(Activity, 
				this, 
				currently.Year, 
				currently.Month,
				currently.Day);
			return dialog;
		}

		/* função que ser implementada por conta do IOnDateSetListener.
		 * Chama a função _dateSelectedHandler quando a nova data é definida.
		 */
		public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
		{
			// Nota: monthOfYear é um valor entre 0 e um, não 1 e 12.
			DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
			Log.Debug(TAG, selectedDate.ToLongDateString());
			_dateSelectedHandler(selectedDate);
		}



	}

}

