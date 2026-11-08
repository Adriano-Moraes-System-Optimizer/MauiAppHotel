# 🏨 Projeto AppHotel - Agenda 14 (.NET MAUI)

Repositório desenvolvido para a entrega da **Agenda 14** do Eixo Tecnológico de Informação e Comunicação (Centro Paula Souza).

## 🚀 Sobre o Projeto
Este projeto é um aplicativo mobile focado no cálculo de diárias de hotel. A principal evolução desta etapa foi a transição para um modelo estruturado com **Orientação a Objetos (POO)** e a validação em tempo real de elementos da interface gráfica.

## 🛠️ Conceitos e Arquitetura Aplicados
* **Classes e Instanciação:** Estruturação das entidades de negócio do sistema (`Quarto`, `ContratacaoHospedagem`).
* **Encapsulamento (Get/Set):** Proteção de dados e regras de negócio. O código barra o preenchimento de quantidades inválidas (números negativos de hóspedes) e valida automaticamente o fluxo cronológico das datas de check-in e check-out inseridas no `DatePicker`.
* **Coleções Dinâmicas:** Implementação de arrays de objetos flexíveis (`List<Quarto>`) para alimentar as opções do Picker na UI.
* **Tratamento de Exceções:** Captura de erros de formatação (`try...catch`) integrados com `DisplayAlert` assíncrono.

## 🎥 Demonstração e Execução
Os testes práticos comprovando a robustez do encapsulamento contra inserções de datas invertidas e dados inconsistentes estão registrados no vídeo de demonstração (`ds2ag14.mp4`), enviado diretamente como anexo na submissão oficial da atividade.

## 💻 Tecnologias Utilizadas
* C#
* .NET MAUI
* XAML
