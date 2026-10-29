using MauiAppHotel.Models;

namespace MauiAppHotel
{
    public partial class MainPage : ContentPage
    {
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto { Descricao = "Suíte Luxo", ValorDiariaAdulto = 250.0, ValorDiariaCrianca = 120.0 },
            new Quarto { Descricao = "Suíte Executiva", ValorDiariaAdulto = 180.0, ValorDiariaCrianca = 90.0 },
            new Quarto { Descricao = "Suíte Simples", ValorDiariaAdulto = 100.0, ValorDiariaCrianca = 50.0 }
        };

        public MainPage()
        {
            InitializeComponent();
            pck_quarto.ItemsSource = lista_quartos;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.Date = DateTime.Now;
            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.Date = DateTime.Now.AddDays(1);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pck_quarto.SelectedItem == null)
                {
                    await DisplayAlert("Aviso", "Por favor, selecione um quarto.", "OK");
                    return;
                }

                ContratacaoHospedagem h = new ContratacaoHospedagem
                {
                    QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
                    QuantidadeAdultos = Convert.ToInt32(stp_adultos.Value),
                    QuantidadeCriancas = Convert.ToInt32(stp_criancas.Value),
                    DataCheckIn = dtpck_checkin.Date ?? DateTime.Now,
                    DataCheckOut = dtpck_checkout.Date ?? DateTime.Now.AddDays(1)
                };

                await DisplayAlert("Resumo da Hospedagem",
                    $"Quarto: {h.QuartoSelecionado.Descricao}\n" +
                    $"Duração: {h.DuracaoEstadia} dia(s)\n" +
                    $"Valor Total: R$ {h.ValorTotal:F2}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void BtnSobre_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SobrePage());
        }
    }
}