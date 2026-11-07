using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class ContratacaoHospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public DateTime DataCheckIn { get; set; }
        private DateTime _dataCheckOut;

        public DateTime DataCheckOut
        {
            get { return _dataCheckOut; }
            set
            {
                // Valida se o check-out é pelo menos 1 dia depois do check-in
                if (value > DataCheckIn)
                    _dataCheckOut = value;
                else
                    throw new ArgumentException("A data de check-out deve ser posterior à data de check-in.");
            }
        }

        // 1. Criamos os campos privados (acesso restrito à própria classe)
        private int _quantidadeAdultos;
        private int _quantidadeCriancas;

        // 2. Criamos a propriedade pública com validação no 'set'
        public int QuantidadeAdultos
        {
            get { return _quantidadeAdultos; }
            set
            {
                if (value >= 1) // Garante pelo menos 1 adulto
                    _quantidadeAdultos = value;
                else
                    throw new ArgumentException("A quantidade de adultos não pode ser menor que 1.");
            }
        }

        public int QuantidadeCriancas
        {
            get { return _quantidadeCriancas; }
            set
            {
                if (value >= 0) // Crianças podem ser 0 ou mais
                    _quantidadeCriancas = value;
                else
                    throw new ArgumentException("A quantidade de crianças não pode ser negativa.");
            }
        }

        public int DuracaoEstadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valor_adultos = QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca;
                double total = (valor_adultos + valor_criancas) * DuracaoEstadia;
                return total == 0 ? valor_adultos + valor_criancas : total;
            }
        }
    }
}