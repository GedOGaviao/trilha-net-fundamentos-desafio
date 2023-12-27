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
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (ValidaPlaca(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veiculo {placa} Foi cadastrado com sucesso");
            }
            else
            {
                Console.WriteLine("A placa do veiculo esta fora do padrão do detran ou mercosul");
            }
        }

        private bool ValidaPlaca(string placa)
        {
            return !string.IsNullOrEmpty(placa) && placa.Length == 8 && (placa[3] == '-' || placa[3] == ' ');
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            string placa = Console.ReadLine();


            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = 0 + precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                }
                else
                {
                    Console.WriteLine("Entrada não valida, para quantidade de horas");
                }


            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                for (int placaNum = 0; placaNum < veiculos.Count; placaNum++)
                {
                    string texto = $"Placa N°{placaNum + 1} - {veiculos[placaNum]}";
                    Console.WriteLine(texto);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
