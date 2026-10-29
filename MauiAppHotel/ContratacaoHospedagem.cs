using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class ContratacaoHospedagem
    {
        public Quarto? QuartoSelecionado { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int DuracaoEstadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                if (QuartoSelecionado == null) return 0;
                double valor_adultos = QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca;
                int dias = DuracaoEstadia > 0 ? DuracaoEstadia : 1;
                return (valor_adultos + valor_criancas) * dias;
            }
        }
    }
}