using System;
namespace ViLanches;

public class Produto
{
    //ATRIBUTOS
    public int Id;
    public string Nome;
   
    public string Observacao;

     public double Preco;
     
   

  

    public Produto(int id, string nome, string observacao, double preco )
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Observacao = observacao;
        
    }

    public void ExibirProduto ()
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine($"  {Id} - {Nome}");
        Console.WriteLine("╠════════════════════════════════════════════════════════════════════════════════════╣");
        Console.WriteLine($"  📝 {Observacao}");
        Console.WriteLine($"  💲 Valor: R$ {Preco:F2}");
        Console.WriteLine("╚━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╝\n");
        
    }
}

public class Cliente
{
    public string Nome;
    public string Endereco;
    public string Telefone;

    public Cliente(string nome, string endereco, string telefone)
    {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
    }

    public void ExibirCliente()
    {
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine($"  Nome: {Nome}");
        Console.WriteLine($"  Endereço: {Endereco}");
        Console.WriteLine($"  Telefone: {Telefone}");
        Console.WriteLine("╚══════════════════════════════╝\n");
    }
}

public class Pedido
{
    public Cliente ClientePedido;

    //lista de produtos
    public List<Produto> Produtos = new List<Produto>();

    //Construtor
    public Pedido(Cliente cliente)
    {
        ClientePedido = cliente;
    }

    public void AdicionarPoduto(Produto produto)
    {
        Produtos.Add(produto);
    }

    public double CalcularTotal()
    {
        double total = 0;
        foreach (Produto p in Produtos)
        {
            total += p.Preco;
        }
        return total;
    }

    public void ExibrPedido()
    {
        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║         PEDIDO               ║");
        Console.WriteLine("╠══════════════════════════════╣");
        Console.WriteLine($"  Cliente: {ClientePedido.Nome}");
        Console.WriteLine( "      \n Itens:"                );
        Console.WriteLine("╚══════════════════════════════╝\n");

        foreach (Produto p in Produtos)
        {
            Console.WriteLine("--"+p.Nome+ "| R$" +p.Preco);

        }

        Console.WriteLine("\nTotal: R$ " + CalcularTotal());
        Console.WriteLine("════════════════════════");

    }
}

public class ConsultaPedido
{
    // LISTA COM TODOS OS PEDIDOS
    public List<Pedido> TodosPedidos = new List<Pedido>();

    // ADICIONAR PEDIDO
    public void AdicionarPedido(Pedido pedido)
    {
        TodosPedidos.Add(pedido);
    }

    // CONSULTAR PEDIDO PELO NOME
    public void ConsultarPorNome(string nomeCliente)
    {
        bool encontrou = false;

        Console.WriteLine("\n╔══════════════════════════════╗");
        Console.WriteLine("║      CONSULTA PEDIDOS        ║");
        Console.WriteLine("╚══════════════════════════════╝\n");

        foreach (Pedido p in TodosPedidos)
        {
            if (p.ClientePedido.Nome.ToLower() == nomeCliente.ToLower())
            {
                p.ExibrPedido();
                encontrou = true;
            }
        }

        if (encontrou == false)
        {
            Console.WriteLine(" Nenhum pedido encontrado.");
        }
    }
}

class Program
{
    static void Main()
    {

        // LISTA DE PRODUTOS
        List<Produto> produtos = new List<Produto>();

        produtos.Add(new Produto(1,"AÇAI SIMPLES", "500ml - Creme de açai, leite condensado, leite em pó", 18.00));
        produtos.Add(new Produto(2,"AÇAI COM MORANGO", "500ML - Creme de açai, leite condensado, leite em pó, morango", 21.00));
        produtos.Add(new Produto(3,"X-BURGUER" ,"Pão, carne bovina, queijo, alface, tomate", 20.00));
        produtos.Add(new Produto(4,"X-BACON", "Pão, carne bovina, queijo, presunto, bacon, alface, tomate", 23.00));
        produtos.Add(new Produto(5,"X-TUDO" , "Pão, carne bovina, ovo, queijo, presunto, bacon, alface, tomate, milho, batata", 28.00));
        produtos.Add(new Produto(6,"REFRIGERANTE LATA 350ML", "COCA COLA - GUARANA - FANTA UVA - FANTA LARANJA", 4.99));
        produtos.Add(new Produto(7,"REFRIGERANTE 1 LITRO", "GUARANA - COCA COLA - SUKITA LARANJA", 5.99));
        produtos.Add(new Produto(8,"SOBREMESA", "BROWNIE", 5.00));

        // CONSULTA
        ConsultaPedido consulta = new ConsultaPedido();

        int opcao = 0;

        while (opcao != 3)
        {
           Console.Clear();

            Console.WriteLine("╔══════════════════════════════╗");
            Console.WriteLine("║🍟 BEM VIDO AO VI LANCHES 🍔 ║");
            Console.WriteLine("╠══════════════════════════════╣");
            Console.WriteLine("║ 1 - Fazer Pedido             ║");
            Console.WriteLine("║ 2 - Consultar Pedidos        ║");
            Console.WriteLine("║ 3 - Sair                     ║");
            Console.WriteLine("╚══════════════════════════════╝");
            Console.Write("\nEscolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:

                    Console.Clear();

                    Console.WriteLine("╔══════════════════════════════╗");
                    Console.WriteLine("║         CARDÁPIO             ║");
                    Console.WriteLine("╚══════════════════════════════╝\n");

                    foreach (Produto p in produtos)
                    {
                        p.ExibirProduto();
                    }
                    Console.WriteLine("Digite seu nome: ");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Digite seu endereço: ");
                    string endereco = Console.ReadLine();

                    Console.WriteLine("Digite seu telefone: ");
                    string telefone = Console.ReadLine();

                    Cliente cliente = new Cliente(nome, endereco, telefone);

                    Pedido pedido = new Pedido(cliente);

                    int idProduto = 0;

                    while (idProduto != 10)
                    {
                     Console.WriteLine("Digite o ID do produto que deseja adicionar ao pedido (ou 10 para finalizar): ");
                     idProduto = int.Parse(Console.ReadLine());

                     if(idProduto == 10)
                     {
                        break;
                     }

                     bool encontrou = false;

                     foreach (Produto p in produtos)
                        {
                            if(p.Id == idProduto)
                            {
                                pedido.AdicionarPoduto(p);
                                Console.WriteLine($"Produto {p.Nome} adicionado com sucesso.");
                                encontrou = true;
                            }
                        }

                        if (encontrou == false)
                        {
                            Console.WriteLine("Produto não encontrado. Tente novamente.");
                        }
                    }

                    // SALVAR PEDIDO
                    consulta.AdicionarPedido(pedido);

                    Console.Clear();

                    Console.WriteLine("PEDIDO FINALIZADO!\n");

                    pedido.ExibrPedido();

                    Console.WriteLine("\nPressione ENTER para voltar");
                    Console.ReadLine();

                    break;

                case 2:

                    Console.Clear();

                    Console.WriteLine("Digite o nome do cliente:");

                    string busca = Console.ReadLine();

                    consulta.ConsultarPorNome(busca);

                    Console.WriteLine("\nPressione ENTER para voltar");
                    Console.ReadLine();

                    break;

                case 3:

                    Console.WriteLine("\nSistema encerrado.");
                    break;

                default:

                    Console.WriteLine("\n Opção inválida.");
                    Console.ReadLine();

                    break;



            }
        }
    }
}
