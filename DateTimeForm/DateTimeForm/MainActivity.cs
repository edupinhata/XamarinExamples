using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace DateTimeForm
{
	[Activity (Label = "DateTimeForm", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle savedInstanceState)
		{
			
			base.OnCreate (savedInstanceState);

			//atribuindo o formulario axml Main à essa classe
			SetContentView (Resource.Layout.Main);


			//Declarando os componentes de Main.axml
			TextView lblDate = FindViewById<TextView>(Resource.Id.lblDate);
			TextView lblTime = FindViewById<TextView> (Resource.Id.lblTime);
			Button btnDate = FindViewById<Button> (Resource.Id.btnDate);
			Button btnTime = FindViewById<Button> (Resource.Id.btnTime);

			//configurando a ação que acontecerá quando o botão de date for clicado.
			btnDate.Click += (object sender, EventArgs e) => {

				/* cria uma instância de DatePickerFragment. Dentro da função delegate, time conterá 
				 * as informações selecionadas no formulário de datas que aparecerá. */
				DatePickerFragment dpf = DatePickerFragment.NewInstance (delegate(DateTime time) {

					/* coloca a data recebida no TextView de data. */
					lblDate.Text = time.ToString ("dd/MM/yy");

				});

				/* mostra o fragmento criado acima para que o usuário interaja com o mesmo. */
				dpf.Show (FragmentManager, DatePickerFragment.TAG);
			};

			/* semelhante à função para data. */
			btnTime.Click += (object sender, EventArgs e) => {
				TimePickerFragment tpf = TimePickerFragment.NewInstance (delegate(DateTime time){
					lblTime.Text = time.ToString("hh:mm tt");
				});

				tpf.Show(FragmentManager, TimePickerFragment.TAG);

			};

		}
	}
}


