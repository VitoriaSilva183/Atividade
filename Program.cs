using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

class Program
{
    // 1. DADOS EM MEMÓRIA (Simplificamos usando variáveis globais)
    static List<Usuario> usuarios = new List<Usuario>();
    static List<string> historico = new List<string>(); // Histórico agora é apenas uma lista de textos

    // 2. MODELO DE USUÁRIO ENXUTO
    class Usuario
    {
        public string Nome;
        public string SenhaHash;
        public int Nivel; // 1 = Visitante, 2 = Funcionário, 3 = Admin
    }

    static void Main()
    {
        usuarios.Add(new Usuario{Nome = "Adminvitoria", SenhaHash = GerarHash("admin7559"), Nivel = 3});

        while (true)
        {
            Console.WriteLine("\n--- CONTROLE DE ACESSO ---");
            Console.WriteLine("Digite o usuario: ");
            string usuario = Console.ReadLine();
            Console.WriteLine("Digite a senha: ");
            string senha = Console.ReadLine();

            string hashUsuario = GerarHash(senha);
            Usuario logado = usuarios.Find(u => u.Nome == usuario && u.SenhaHash == hashUsuario);
            if (logado == null)
            {
                Console.WriteLine("Login ou senha incorretos.");
                continue;
            }

            Console.WriteLine($"Bem vindo, {logado.Nome}! (Nivel: {logado.Nivel})");
            Console.WriteLine("1- Acessar Area / 2- Cadastrar Usuario (Admin) / 3- Ver Historico (Admin) / 0- Sair");
            Console.WriteLine("Escolha: ");
            string opcao = Console.ReadLine();

            if (opcao == "0") break;

            if(opcao == "1")
            {
                Console.WriteLine("Qual area deseja acessar?(Recepçao / Cirurgia / Servidor):");
                string area = Console.ReadLine();
                bool liberado = false;

                if (logado.Nivel == 3)
                
                    liberado = true; 
                
                else if(logado.Nivel == 2 && (area == "Recepcao" || area == "Cirurgia"))
                
                    liberado = true;
                
                else if(logado.Nivel == 1 && area == "Recepcao")
                
                    liberado = true;

                string status = liberado ? "AUTORIZADO" : "NEGADO";
                string registro =
                $"Data: {DateTime.Now:dd/MM/yyyy} | " +
                $"Hora: {DateTime.Now:HH:mm:ss} | " +
                $"Usuario: {logado.Nome} | " +
                $"Area: {area} | " +
                $"Resultado: {status}";

                historico.Add(registro);

                Console.WriteLine($"\nAcesso {status}");

            }
            else if(opcao == "2" && logado.Nivel == 3)
            {
                Console.WriteLine("Novo Usuario: ");
                string novoNome = Console.ReadLine();
                Console.WriteLine("Nova Senha: ");
                string novaSenha = Console.ReadLine();
                Console.WriteLine("Nivel(1-Visitante, 2-Funcionario, 3-Admin):");
                int nivel = int.Parse(Console.ReadLine());

                usuarios.Add(new Usuario {Nome = novoNome, SenhaHash = GerarHash(novaSenha), Nivel = nivel});
                Console.WriteLine("Usuario cadastro com sucesso!");

            }
            else if(opcao == "3" && logado.Nivel == 3)
            {
                Console.WriteLine("\n --- HISTORICO---");
                foreach (string registro in historico)
                {
                    Console.WriteLine(registro);
                }
            }
            else
            {
                Console.WriteLine("/nOpçao invalida ou você não tem permissão de Administrador.");
            }
        }
    }
    static string GerarHash(string senha)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return Convert.ToBase64String(bytes); // Convert.ToBase64String deixa o código bem mais curto

        }
    }
}