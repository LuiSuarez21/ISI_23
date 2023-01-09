﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * Autores do projecto: Luis Esteves/16960 || João Ribeiro/17214;
 * Disciplina: Integração de Sistemas de Informação;
 * Projecto II;
 * Propósito do trabalho: Criar uma API SOAP e uma API REST Full de gerência de utilizadores e de entrega de livros;
 *
 */

namespace SOAP.Services
{
   
    public class Client : IClient
    {
        string connectionString = "Server=tcp:isi.database.windows.net,1433;Initial Catalog=ISI_TP2;Persist Security Info=False;User ID=ISI_SuperAdmin;Password=Teste1234++;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        /// <summary>
        /// Inserir Cliente
        /// </summary>
        /// <param name="Id_Client"></param>
        /// <param name="name"></param>
        /// <param name="morada"></param>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <param name="telemovel"></param>
        /// <param name="DataNascimento"></param>
        public async Task<bool> InsertClientAsync(int Id_Client, string name, string morada, string email, string pass, int telemovel, DateTime DataNascimento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (Id_Client == -1 || name == null || morada == null || email == null || pass == null || telemovel == -1)
                {
                    return false;
                }

                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("INSERT INTO Cliente(ID_Cliente, Nome, Morada, Email, Pass, Telemovel, DataNascimento) VALUES(@ID_CLIENTE, @NOME, @MORADA, @EMAIL, @PASS, @TELEMOVEL, @DATANASCIMENTO)", connection))
                {
                    command.Parameters.AddWithValue("@ID_CLIENTE", Id_Client);
                    command.Parameters.AddWithValue("@NOME", name);
                    command.Parameters.AddWithValue("@MORADA", morada);
                    command.Parameters.AddWithValue("@EMAIL", email);
                    command.Parameters.AddWithValue("@PASS", pass);
                    command.Parameters.AddWithValue("@TELEMOVEL", telemovel);
                    command.Parameters.AddWithValue("@DATANASCIMENTO", DataNascimento);
                    await command.ExecuteNonQueryAsync();
                }
            }
            return true;
        }

        public bool InsertBook(int Id_Livros, string title, string author, string genre, double ratings, string cover_type, double price, int quantidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                if (Id_Livros == -1 || title == null || author == null || genre == null || ratings == -1 || cover_type == null || price == -1 || quantidade == -1)
                {
                    return false;
                }
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Books (ID_Livros, title, author, genre, ratings, cover_type, price, quantidade) VALUES (@ID_LIVROS, @TITLE, @AUTHOR, @GENRE, @RATINGS, @COVER_TYPE, @PRICE, @QUANTIDADE)", connection))
                {
                    command.Parameters.AddWithValue("@ID_LIVROS", Id_Livros);
                    command.Parameters.AddWithValue("@TITLE", title);
                    command.Parameters.AddWithValue("@AUTHOR", author);
                    command.Parameters.AddWithValue("@GENRE", genre);
                    command.Parameters.AddWithValue("@RATINGS", ratings);
                    command.Parameters.AddWithValue("@COVER_TYPE", cover_type);
                    command.Parameters.AddWithValue("@PRICE", price);
                    command.Parameters.AddWithValue("@QUANTIDADE", quantidade);
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }


        public void InsertOrder(int Id_Encomenda, int Id_Pedido, int Id_Client, string Estado)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Encomenda (ID_Encomenda, ID_Pedido, ID_Cliente, Estado) VALUES (@ID_ENCOMENDA, @ID_PEDIDO, @ID_CLIENTE, @ESTADO)", connection))
                {
                    command.Parameters.AddWithValue("@ID_ENCOMENDA", Id_Encomenda);
                    command.Parameters.AddWithValue("@ID_PEDIDO", Id_Pedido);
                    command.Parameters.AddWithValue("@ID_CLIENTE", Id_Client);
                    command.Parameters.AddWithValue("@ESTADO", Estado);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void InsertRequest(int Id_Pedido, int Id_Livro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Pedidos (ID_Pedido ,ID_Livro) VALUES (@ID_PEDIDO ,@ID_LIVRO)", connection))
                {
                    command.Parameters.AddWithValue("@ID_PEDIDO", Id_Pedido);
                    command.Parameters.AddWithValue("@ID_LIVRO", Id_Livro);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateClient(int Id_Client, string name, string morada, string email, string pass, int telemovel, DateTime DataNascimento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Cliente SET ID_Cliente=@ID_Cliente, Nome=@Nome, Morada=@Morada, Email=@Email, Pass=@Pass, Telemovel=@Telemovel, DataNascimento=@DataNascimento WHERE ID_Cliente=@ID_Cliente", connection))
                {
                    command.Parameters.AddWithValue("@ID_Cliente", Id_Client);
                    command.Parameters.AddWithValue("@Nome", name);
                    command.Parameters.AddWithValue("@Morada", morada);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Pass", pass);
                    command.Parameters.AddWithValue("@Telemovel", telemovel);
                    command.Parameters.AddWithValue("@DataNascimento", DataNascimento);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBook(int Id_Livros, string title, string author, string genre, double ratings, string cover_type, double price, int quantidade)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Books SET ID_Livros=@ID_Livros, Title=@Title, Author=@Author, Genre=@Genre, Ratings=@Ratings, Cover_Type=@Cover_Type, Price=@Price, Quantidade=@Quantidade WHERE ID_Livros=@ID_Livros", connection))
                {
                    command.Parameters.AddWithValue("@ID_Livros", Id_Livros);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Author", author);
                    command.Parameters.AddWithValue("@Genre", genre);
                    command.Parameters.AddWithValue("@Ratings", ratings);
                    command.Parameters.AddWithValue("@Cover_Type", cover_type);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Quantidade", quantidade);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOrder(int Id_Encomenda, int Id_Pedido, int Id_Client, string Estado)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Encomenda SET ID_Encomenda=@ID_Encomenda, ID_Pedido=@ID_Pedido, ID_Cliente=@ID_Cliente, Estado=@Estado WHERE ID_Encomenda=@ID_Encomenda", connection))
                {
                    command.Parameters.AddWithValue("@ID_Encomenda", Id_Encomenda);
                    command.Parameters.AddWithValue("@ID_Pedido", Id_Pedido);
                    command.Parameters.AddWithValue("@ID_Cliente", Id_Client);
                    command.Parameters.AddWithValue("@Estado", Estado);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRequest(int Id_Pedido, int Id_Livro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Pedidos SET ID_Pedido=@ID_Pedido, ID_Livro=@ID_Livro WHERE ID_Pedido=@ID_Pedido", connection))
                {
                    command.Parameters.AddWithValue("@ID_Pedido", Id_Pedido);
                    command.Parameters.AddWithValue("@ID_Livro", Id_Livro);
                    command.ExecuteNonQuery();
                }
            }
        }



        public void DeleteClient(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Delete from dbo.Cliente where ID_Cliente=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBook(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Delete from dbo.Books where ID_Livros=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Delete from dbo.Encomenda where ID_Encomenda=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRequest(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Delete from lockers where ID_Pedido=@Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
