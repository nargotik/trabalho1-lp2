﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITgestao;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ITgestao
{
    class Program
    {
        
        static Equipamento[] _equip;
        public static void ShowEquipamento(Equipamento pub)
        {
            int pubDate = pub.Id;
            Console.WriteLine($"{pub.Id}");

            Console.WriteLine($"{pub.ToString()}");
            // WriteLine($"{pub.Title}, " +
            //           $"{(pubDate == "NYP" ? "Not Yet Published" : "published on " + pubDate):d} by {pub.Publisher}");
        }
        static void Main(string[] args)
        {
            

            Computador _com = new Computador(12, "222");
            
            ShowEquipamento(_com);

            Console.WriteLine($"{_com.ToString()}");
            Console.WriteLine($"Serial: {_com.Serial}");
            Console.ReadKey();

            
            Console.WriteLine("Insira o id > 0: ");
            int id = Convert.ToInt32(Console.ReadLine());
            
            try
            {
                Inventario inv = new Inventario(id);
                inv.Adiciona(_com);
               //Equipamento.Rede _rede = new Equipamento.Rede(12);
                //inv.Adiciona(_rede);

                //IFormatter formatter = new BinaryFormatter();
                //Stream stream = new FileStream(@"ExampleNew.txt", FileMode.Create, FileAccess.Write);

                //formatter.Serialize(stream, _rede);
                //stream.Close();
            }
            catch (Exception ex)
            {
                // Exception that comes from creation of Equipment
                Console.WriteLine("Não foi criado");
                Console.WriteLine(ex.Message);
            }


                try
            {
                // Tenta inicializar um equipamento 
                Equipamento equi = new Equipamento(TipoEquipamento.Computador , id);
                // Mostra a mensagem de sucesso
                Console.WriteLine($"Foi criado {equi.Id}");

                // Adiciona à lista de equipamentos


            } catch (IdBadException ex) {
                // Exception that comes from creation of Equipment
                Console.WriteLine("Não foi criado");
                Console.WriteLine(ex.Message);
            } catch (IdDuplicatedException ex)
                // Exeption that comes from equipments handler for a duplicate entry

            {

            }

            try
            {
                Equipamento.Rede _rede = new Equipamento.Rede(66, "1234");
                Console.WriteLine($"Foi criado {_rede.Id}");
                Console.WriteLine($"Foi criado {Utils.HasMethod(_rede, "Adiciona")}");
            } catch(InitBadException)
            {

            }


            




            Console.ReadKey();

        }


        
    }
}
