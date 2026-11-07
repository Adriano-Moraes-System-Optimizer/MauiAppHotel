using Microsoft.Maui.Controls;
using MauiAppHotel.Models;
using System;
using System.Collections.Generic;

namespace MauiAppHotel
{
    public partial class MainPage : ContentPage
    {
        // A lista foi declarada corretamente DENTRO da classe MainPage
        public List<Quarto> lista_quartos = new List<Quarto>
        {
            new Quarto { Descricao = "Suíte Luxo", ValorDiariaAdulto = 250.0, ValorDiariaCrianca = 120.0 },
            new Quarto { Descricao = "Suíte Executiva", ValorDiariaAdulto = 180.0, ValorDiariaCrianca = 90.0 },
            new Quarto { Descricao = "Suíte Simples", ValorDiariaAdulto = 100.0, ValorDiariaCrianca = 50.0 }
        };

        public MainPage()
        {
            InitializeComponent();

            // Liga os dados ao layout no momento em que a tela nasce
            pck_quarto.ItemsSource = lista_quartos;
        }

        // O método do botão também está DENTRO da classe
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pck_quarto.SelectedItem == null)
                {
                    await DisplayAlert("Aviso", "Por favor, selecione um quarto.", "OK");
                    return;
                }

                ContratacaoHospedagem h = new ContratacaoHospedagem();

                // 1. O Check-in precisa ser preenchido primeiro com o .Value para a validação do Check-out funcionar
                h.DataCheckIn = dtpck_checkin.Date.Value;
                h.DataCheckOut = dtpck_checkout.Date.Value; // O .Value corrige os 2 erros CS0266 da sua imagem

                // 2. Os demais dados são carregados acionando o encapsulamento
                h.QuartoSelecionado = (Quarto)pck_quarto.SelectedItem;
                h.QuantidadeAdultos = Convert.ToInt32(stp_adultos.Value);
                h.QuantidadeCriancas = Convert.ToInt32(stp_criancas.Value);

                await DisplayAlert("Resumo da Hospedagem",
                    $"Quarto: {h.QuartoSelecionado.Descricao}\n" +
                    $"Duração: {h.DuracaoEstadia} dia(s)\n" +
                    $"Valor Total: R$ {h.ValorTotal:F2}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro de Validação", ex.Message, "OK");
            }
        }
    }
}