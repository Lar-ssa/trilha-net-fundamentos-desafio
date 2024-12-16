namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper().Trim();

            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Placa inválida! Pressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso!");
                Console.ReadKey();
            }

        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper().Trim();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas;

                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Por favor, digite um número válido de horas (não negativo).");
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                }

                decimal valorTotal = precoInicial + precoPorHora * Math.Max(horas - 1, 0); // 1ª hora tem preço fixo

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
            else
            {
                Console.WriteLine("Veículos estacionados:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
        }
    }
}
